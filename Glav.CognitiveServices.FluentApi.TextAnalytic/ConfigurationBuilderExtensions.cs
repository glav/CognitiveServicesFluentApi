using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public static class ConfigurationBuilderExtensions
    {
        public static TextAnalyticAnalysisSettings WithTextAnalyticAnalysisActions(this CoreAnalysisSettings analysisSettings)
        {
            return new TextAnalyticAnalysisSettings(analysisSettings);
        }


    }
}
