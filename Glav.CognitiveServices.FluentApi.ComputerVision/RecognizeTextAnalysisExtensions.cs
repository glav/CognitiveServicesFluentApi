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
    public static class RecognizeTextAnalysisExtensions
    {
        public static async Task<IEnumerable<OperationStatusResult>> CheckOperationStatusAsync(this ComputerVisionAnalysisResults results)
        {
            var operationStatusToQuery = results.RecognizeTextAnalysis.AnalysisResults.Select(s => s.ApiCallResult.OperationLocationUri).ToList();
            var statusResponses = new List<OperationStatusResult>(operationStatusToQuery.Count);
            var queryEngine = new OperationStatusQueryEngine(results.AnalysisSettings);
            foreach (var statusUri in operationStatusToQuery)
            {
                statusResponses.Add(await queryEngine.CheckOperationStatusAsync(statusUri));
            }
            return statusResponses;
        }

        public static async Task<IEnumerable<RecognizeTextAnalysisResult>> WaitForOperationToCompleteAsync(this ComputerVisionAnalysisResults results, int timeoutInMillseconds = 300000)
        {
            var operationStatusToQuery = results.RecognizeTextAnalysis.AnalysisResults.Select(s => s.ApiCallResult.OperationLocationUri).ToList();
            var analysisResponses = new List<RecognizeTextAnalysisResult>(operationStatusToQuery.Count);
            var queryEngine = new OperationStatusQueryEngine(results.AnalysisSettings);
            var cancelToken = new CancellationToken();
            foreach (var statusUri in operationStatusToQuery)
            {
                var callResult = await queryEngine.WaitForOperationToCompleteAsync(statusUri, cancelToken, timeoutInMillseconds);
                analysisResponses.Add(new RecognizeTextAnalysisResult(callResult.ApiCallResult));
            }
            return analysisResponses;
        }
    }
}
