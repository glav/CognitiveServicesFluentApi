using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class TextAnalyticConfigurationSettings : ConfigurationSettings
    {
        public TextAnalyticConfigurationSettings(string apiKey) 
                : base(ApiActionCategory.TextAnalytics,apiKey, new ApiServiceUrlFragments())
        {
        }

        public TextAnalyticConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        public static TextAnalyticConfigurationSettings CreateUsingApiKey(string apiKey)
        {
            return new TextAnalyticConfigurationSettings(apiKey);
        }
    }
}
