using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public static class TextAnalyticTopicFluentApiExtensions
    {
        private const int OperationStateQueryDelayInMilliseconds = 3000;
        private const int OperationStateQueryTimoutInMilliseconds = 300000;

        public static async Task<OperationStatusResult> CheckTopicAnalysisStatusAsync(this TextAnalyticAnalysisResults analysisResults)
        {
            var queryEngine = new OperationStatusQueryEngine(analysisResults);
            var result = await queryEngine.CheckOperationStatus();
            return result;
        }

        public static async Task<OperationStatusResult> WaitForTopicAnalysisToCompleteAsync(this TextAnalyticAnalysisResults analysisResults, 
            int timeoutInMilliseconds = OperationStateQueryTimoutInMilliseconds)
        {
            var cancelToken = CancellationToken.None;
            return await WaitForTopicAnalysisToCompleteAsync(analysisResults, cancelToken, timeoutInMilliseconds);
        }
        public static async Task<OperationStatusResult> WaitForTopicAnalysisToCompleteAsync(this TextAnalyticAnalysisResults analysisResults, 
            CancellationToken cancelToken, 
            int timeoutInMilliseconds = OperationStateQueryTimoutInMilliseconds)
        {
            var queryEngine = new OperationStatusQueryEngine(analysisResults);
            var result = await queryEngine.CheckOperationStatus();
            if (HasOperationEnded(result.OperationState))
            {
                return result;
            }

            analysisResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo("Waiting for operation status to complete...", "TextAnalysis");

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                while (true)
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        analysisResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo("Querying operation status was cancelled", "TextAnalysis");
                        return OperationStatusResult.CreateCancelledOperation(result.ApiCallResult);
                    }
                    result = await queryEngine.CheckOperationStatus();
                    if (HasOperationEnded(result.OperationState))
                    {
                        analysisResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Querying for operation status completed in {stopWatch.ElapsedMilliseconds} milliseconds.", "TextAnalysis");

                        return result;
                    }

                    await System.Threading.Tasks.Task.Delay(OperationStateQueryDelayInMilliseconds);

                    if (stopWatch.ElapsedMilliseconds > timeoutInMilliseconds)
                    {
                        analysisResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Querying for operation status timed out. Operation took {stopWatch.ElapsedMilliseconds} which was greater than threshold {timeoutInMilliseconds} milliseconds.", "TextAnalysis");

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
