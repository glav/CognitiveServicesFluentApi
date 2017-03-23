using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System.Linq;
using Glav.CognitiveServices.Api.Fluent.Contracts;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.Api.Fluent
{
    public static class TextAnalyticTopicFluentApiExtensions
    {

        public static async Task<OperationStatusResult> CheckTopicAnalysisStatusAsync(this ApiAnalysisResults analysisResults)
        {
            var queryEngine = new OperationStatusQueryEngine(analysisResults.AnalysisSettings.ConfigurationSettings, analysisResults.TextAnalyticTopicAnalysis.AnalysisResult);
            var result = await queryEngine.CheckOperationStatus();
            return result;
        }

    }
}
