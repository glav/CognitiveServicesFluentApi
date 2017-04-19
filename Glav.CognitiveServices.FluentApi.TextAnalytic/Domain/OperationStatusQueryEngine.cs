using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public sealed class OperationStatusQueryEngine
    {
        private readonly TextAnalyticAnalysisResults _analysisResults;

        public OperationStatusQueryEngine(TextAnalyticAnalysisResults analysisResults)
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
