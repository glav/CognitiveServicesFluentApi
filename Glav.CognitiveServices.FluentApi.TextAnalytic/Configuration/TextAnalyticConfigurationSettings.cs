using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class TextAnalyticConfigurationSettings : ConfigurationSettings
    {
        public TextAnalyticConfigurationSettings(string apiKey, ApiServiceUrlFragmentsBase serviceUrls)
        {
            ApiKey = apiKey;

        }

        public TextAnalyticConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {

        }
    }
}
