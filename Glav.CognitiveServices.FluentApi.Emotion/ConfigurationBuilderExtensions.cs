using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Emotion.Configuration;

namespace Glav.CognitiveServices.FluentApi.Emotion
{
    public static class ConfigurationBuilderExtensions
    {
        public static EmotionAnalysisSettings WithEmotionAnalysisActions(this CoreAnalysisSettings analysisSettings)
        {
            return new EmotionAnalysisSettings(analysisSettings);
        }


    }
}
