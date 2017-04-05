using Glav.CognitiveServices.Api.Configuration;
using Glav.CognitiveServices.Api.Communication;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class OperationStatusQueryEngine
    {
        private readonly AnalysisResults _analysisResults;

        public OperationStatusQueryEngine(AnalysisResults analysisResults)
        {
            _analysisResults = analysisResults;
        }

        public async Task<OperationStatusResult> CheckOperationStatus()
        {
            var commsEngine = _analysisResults.AnalysisSettings.CommunicationEngine;
            var serviceResult = await commsEngine.CallServiceAsync(_analysisResults.TextAnalyticTopicAnalysis.AnalysisResult.ApiCallResult.OperationLocationUri.AbsoluteUri);
            var result = new OperationStatusResult(serviceResult);
            return result;
        }
    }
}
