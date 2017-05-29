using Glav.CognitiveServices.FluentApi.Core.Configuration;
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
            _analysisResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo("About to query operation status", "OperationStatusQuery");
            var commsEngine = _analysisResults.AnalysisSettings.CommunicationEngine;
            var serviceResult = await commsEngine.CallServiceAsync(_analysisResults.TextAnalyticTopicAnalysis.AnalysisResult.ApiCallResult.OperationLocationUri.AbsoluteUri, ApiActionCategory.TextAnalytics);
            var result = new OperationStatusResult(serviceResult);
            return result;
        }
    }
}
