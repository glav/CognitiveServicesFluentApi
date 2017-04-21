using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Emotion.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class EmotionConfigurationSettings : ConfigurationSettings
    {
        public EmotionConfigurationSettings(string apiKey) 
                : base(ApiActionCategory.Emotion,apiKey, new ApiServiceUrlFragments())
        {
        }

        public EmotionConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        public static EmotionConfigurationSettings CreateUsingApiKey(string apiKey)
        {
            return new EmotionConfigurationSettings(apiKey);
        }
    }
}
