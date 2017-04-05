using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System.Linq;
using Glav.CognitiveServices.Api.Fluent.Contracts;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Glav.CognitiveServices.Api.Fluent
{
    public static class TextAnalyticTopicFluentApiExtensions
    {
        private const int OperationStateQueryDelayInMilliseconds = 2000;
        private const int OperationStateQueryTimoutInMilliseconds = 300000;

        public static async Task<OperationStatusResult> CheckTopicAnalysisStatusAsync(this AnalysisResults analysisResults)
        {
            var queryEngine = new OperationStatusQueryEngine(analysisResults);
            var result = await queryEngine.CheckOperationStatus();
            return result;
        }

        public static async Task<OperationStatusResult> WaitForTopicAnalysisToCompleteAsync(this AnalysisResults analysisResults, 
            int timeoutInMilliseconds = OperationStateQueryTimoutInMilliseconds)
        {
            var cancelToken = CancellationToken.None;
            return await WaitForTopicAnalysisToCompleteAsync(analysisResults, cancelToken, timeoutInMilliseconds);
        }
        public static async Task<OperationStatusResult> WaitForTopicAnalysisToCompleteAsync(this AnalysisResults analysisResults, 
            CancellationToken cancelToken, 
            int timeoutInMilliseconds = OperationStateQueryTimoutInMilliseconds)
        {
            var queryEngine = new OperationStatusQueryEngine(analysisResults);
            var result = await queryEngine.CheckOperationStatus();
            if (HasOperationEnded(result.OperationState))
            {
                return result;
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                while (true)
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        return OperationStatusResult.CreateCancelledOperation(result.ApiCallResult);
                    }
                    result = await queryEngine.CheckOperationStatus();
                    if (HasOperationEnded(result.OperationState))
                    {
                        return result;
                    }
                    System.Threading.Thread.Sleep(OperationStateQueryDelayInMilliseconds);
                    if (stopWatch.ElapsedMilliseconds > timeoutInMilliseconds)
                    {
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
