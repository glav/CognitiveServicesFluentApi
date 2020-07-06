using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Luis.Configuration;

namespace Glav.CognitiveServices.FluentApi.Luis
{
    public static class ConfigurationBuilderExtensions
    {
        public static LuisAnalysisSettings WithLuisAnalysisActions(this CoreAnalysisSettings analysisSettings)
        {
            return new LuisAnalysisSettings(analysisSettings);
        }


    }
}
