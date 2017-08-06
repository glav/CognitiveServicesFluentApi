using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;

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
