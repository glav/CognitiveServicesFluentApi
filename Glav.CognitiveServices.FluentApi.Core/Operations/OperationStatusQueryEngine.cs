using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Diagnostics;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Core.Operations
{

    public sealed class OperationStatusQueryEngine
    {
        private readonly CoreAnalysisSettings _analysisSettings;

        public const int DefaultOperationStateQueryDelayInMilliseconds = 3000;
        public const int DefaultOperationStateQueryTimeoutInMilliseconds = 300000;
        private const string LoggingTopic = "OperationStatus";


        public OperationStatusQueryEngine(CoreAnalysisSettings analysisSettings)
        {
            _analysisSettings = analysisSettings;

        }

        public async Task<OperationStatusResult> CheckOperationStatusAsync(Uri operationStatusLocationUri)
        {
            _analysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo("About to query operation status", "OperationStatusQuery");
            var serviceResult = await _analysisSettings.CommunicationEngine.CallServiceAsync(operationStatusLocationUri.AbsoluteUri, _analysisSettings.ConfigurationSettings.ApiCategory);
            var result = new OperationStatusResult(serviceResult);
            _analysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo("Completed query operation status", "OperationStatusQuery");
            return result;
        }

        public async Task<OperationStatusResult> WaitForOperationToCompleteAsync(Uri operationStatusLocationUri,
            CancellationToken cancelToken,
            int timeoutInMilliseconds = DefaultOperationStateQueryTimeoutInMilliseconds,
            int queryDelayInMilliseconds = DefaultOperationStateQueryDelayInMilliseconds)
        {
            var result = await CheckOperationStatusAsync(operationStatusLocationUri);
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
                    result = await CheckOperationStatusAsync(operationStatusLocationUri);
                    if (HasOperationEnded(result.OperationState))
                    {
                        _analysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Querying for operation status " +
                            $"completed in {stopWatch.ElapsedMilliseconds} milliseconds.", LoggingTopic);

                        return result;
                    }

                    await System.Threading.Tasks.Task.Delay(queryDelayInMilliseconds);

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
