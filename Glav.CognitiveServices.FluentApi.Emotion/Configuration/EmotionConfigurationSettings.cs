using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Emotion.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion.Configuration
{
    public class EmotionConfigurationSettings : ConfigurationSettings
    {
        public EmotionConfigurationSettings(string apiKey, LocationKeyIdentifier locationKey) 
                : base(ApiActionCategory.Emotion,apiKey,locationKey, new ApiServiceUrlFragments())
        {
        }

        public EmotionConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        public static EmotionConfigurationSettings CreateUsingConfigurationKeys(string apiKey, LocationKeyIdentifier locationKey)
        {
            return new EmotionConfigurationSettings(apiKey, locationKey);
        }
    }
}
