using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Operations;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class ReadImageAnalysisExtensions
    {
        /// <summary>
        /// Queries the result of a Read API call.
        /// </summary>
        /// <param name="results"></param>
        /// <returns>An enumerated list of <see cref="OperationStatusResult"/>. This contains the following possible statu: NotStarted, BadRequest,
        /// Submitted,Running,CompletedSuccessfully,Failed,TimedOut,Cancelled,Uploaded</returns>
        public static async Task<IEnumerable<OperationStatusResult>> CheckOperationStatusAsync(this ComputerVisionAnalysisResults results)
        {
            var operationStatusToQuery = results.ReadImageAnalysis.AnalysisResults.Select(s => s.ApiCallResult.OperationLocationUri).ToList();
            var statusResponses = new List<OperationStatusResult>(operationStatusToQuery.Count);
            var queryEngine = new OperationStatusQueryEngine(results.AnalysisSettings);
            foreach (var statusUri in operationStatusToQuery)
            {
                statusResponses.Add(await queryEngine.CheckOperationStatusAsync(statusUri));
            }
            return statusResponses;
        }

        /// <summary>
        /// Will poll the operation status service until the ReadImage operation has completed processing.
        /// </summary>
        /// <param name="results">The Read image analysis results</param>
        /// <param name="cancelToken">Cancellation token for the task</param>
        /// <param name="timeoutInMillseconds">The total timeout period in milliseconds for the wait operation. 
        /// This wait operation will efectively poll the operation status endpoint until the total time taken exceeds this value.</param>
        /// <param name="queryDelayInMilliseconds">The delay between each query operation to the API.</param>
        /// <returns>An enumerable list of <see cref="ReadImageAnalysisResult"/></returns>
        public static async Task<IEnumerable<ReadImageAnalysisResult>> WaitForOperationToCompleteAsync(this ComputerVisionAnalysisResults results, CancellationToken cancelToken, int timeoutInMillseconds, int queryDelayInMilliseconds)
        {
            var operationStatusToQuery = results.ReadImageAnalysis.AnalysisResults.Select(s => s.ApiCallResult.OperationLocationUri).ToList();
            var analysisResponses = new List<ReadImageAnalysisResult>(operationStatusToQuery.Count);
            var queryEngine = new OperationStatusQueryEngine(results.AnalysisSettings);
            foreach (var statusUri in operationStatusToQuery)
            {
                var callResult = await queryEngine.WaitForOperationToCompleteAsync(statusUri, cancelToken, timeoutInMillseconds,queryDelayInMilliseconds);
                analysisResponses.Add(new ReadImageAnalysisResult(callResult.ApiCallResult));
            }
            return analysisResponses;
        }

        /// <summary>
        /// Will poll the operation status service until the ReadImage operation has completed processing. The total timeout period for this operation
        /// (or effectively the maximum time to wait) defaults to 30 seconds with a 3 second delay between  each query of the operation status endpoint.
        /// </summary>
        /// <param name="results">The RecognizeText analysis results</param>
        /// <returns>An enumerable list of <see cref="ReadImageAnalysisResult"/></returns>
        public static async Task<IEnumerable<ReadImageAnalysisResult>> WaitForOperationToCompleteAsync(this ComputerVisionAnalysisResults results)
        {
            var cancelToken = new CancellationToken();
            return await WaitForOperationToCompleteAsync(results, cancelToken, OperationStatusQueryEngine.DefaultOperationStateQueryTimeoutInMilliseconds, OperationStatusQueryEngine.DefaultOperationStateQueryDelayInMilliseconds);
        }
    }
}
