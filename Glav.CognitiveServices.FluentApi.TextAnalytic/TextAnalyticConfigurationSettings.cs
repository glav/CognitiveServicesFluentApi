using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Diagnostics;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public class TextAnalyticConfigurationSettings : ConfigurationSettings
    {
        public TextAnalyticConfigurationSettings(string apiKey, LocationKeyIdentifier locationKey) 
                : base(ApiActionCategory.TextAnalytics,apiKey, locationKey, new ApiServiceUrlFragments())
        {
        }

        public TextAnalyticConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        public static TextAnalyticConfigurationSettings CreateUsingConfigurationKeys(string apiKey, LocationKeyIdentifier locationKey)
        {
            return new TextAnalyticConfigurationSettings(apiKey,locationKey);
        }
    }
}
