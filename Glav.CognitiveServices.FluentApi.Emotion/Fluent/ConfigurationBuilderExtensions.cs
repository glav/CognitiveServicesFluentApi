using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion.Fluent
{
    public static class ConfigurationBuilderExtensions
    {
        public static ConfigurationSettings CreateUsingApiKeyForEmotion(this EmotionConfigurationSettings configSettings, string apiKey)
        {
            var config = new EmotionConfigurationSettings(apiKey);
            return config;
        }

    }
}
