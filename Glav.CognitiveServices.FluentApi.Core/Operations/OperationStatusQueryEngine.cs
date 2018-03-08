using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Core.Operations
{

    public sealed class OperationStatusQueryEngine
    {
        private readonly IDiagnosticLogger _logger;
        private readonly CoreAnalysisSettings _analysisSettings;
        private readonly Uri _operationStatusLocationUri;
        private readonly ConfigurationSettings _configurationSettings;
        private readonly ApiActionCategory _apiCategory;

        public const int DefaultOperationStateQueryDelayInMilliseconds = 3000;
        public const int DefaultOperationStateQueryTimeoutInMilliseconds = 300000;
        private const string LoggingTopic = "OperationStatus";


        public OperationStatusQueryEngine(CoreAnalysisSettings analysisSettings, Uri operationStatusLocationUri, 
                                            ApiActionCategory apiCategory, IDiagnosticLogger logger)
        {
            _analysisSettings = analysisSettings;
            _operationStatusLocationUri = operationStatusLocationUri;
            _apiCategory = apiCategory;
            _logger = logger;

        }

        public async Task<OperationStatusResult> CheckOperationStatusAsync()
        {
            _logger.LogInfo("About to query operation status", "OperationStatusQuery");
            var serviceResult = await _analysisSettings.CommunicationEngine.CallServiceAsync(_operationStatusLocationUri.AbsoluteUri, _apiCategory);
            var result = new OperationStatusResult(serviceResult);
            _logger.LogInfo("Completed query operation status", "OperationStatusQuery");
            return result;
        }

        public async Task<OperationStatusResult> WaitForTopicOperationToCompleteAsync(CancellationToken cancelToken,
            int timeoutInMilliseconds = DefaultOperationStateQueryTimeoutInMilliseconds)
        {
            var result = await CheckOperationStatusAsync();
            if (HasOperationEnded(result.OperationState))
            {
                return result;
            }

            _analysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo("Waiting for operation status to complete...", LoggingTopic);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                while (true)
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        _analysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo("Querying operation status was cancelled", LoggingTopic);
                        return OperationStatusResult.CreateCancelledOperation(result.ApiCallResult);
                    }
                    result = await CheckOperationStatusAsync();
                    if (HasOperationEnded(result.OperationState))
                    {
                        _analysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Querying for operation status " +
                            $"completed in {stopWatch.ElapsedMilliseconds} milliseconds.", LoggingTopic);

                        return result;
                    }

                    await System.Threading.Tasks.Task.Delay(DefaultOperationStateQueryDelayInMilliseconds);

                    if (stopWatch.ElapsedMilliseconds > timeoutInMilliseconds)
                    {
                        _analysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Querying for operation status timed out." +
                            $" Operation took {stopWatch.ElapsedMilliseconds} which was greater than threshold {timeoutInMilliseconds} milliseconds.", LoggingTopic);

                        return OperationStatusResult.CreateTimeoutOperation(result.ApiCallResult);
                    }
                }
            }
            finally
            {
                stopWatch.Stop();
            }
        }

        private static bool HasOperationEnded(OperationStateType operationState)
        {
            return (operationState == OperationStateType.BadRequest
                    || operationState == OperationStateType.CompletedSuccessfully
                    || operationState == OperationStateType.Failed);
        }

    }
}
