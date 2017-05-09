using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Emotion.Configuration;

namespace Glav.CognitiveServices.FluentApi.Emotion.Fluent
{
    public static class ConfigurationBuilderExtensions
    {
        public static ConfigurationSettings CreateUsingConfigurationKeysForEmotion(this EmotionConfigurationSettings configSettings, string apiKey, LocationKeyIdentifier locationKey)
        {
            var config = new EmotionConfigurationSettings(apiKey,locationKey);
            return config;
        }

    }
}
