using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent
{
    public static class ConfigurationBuilderExtensions
    {
        public static ConfigurationSettings CreateUsingConfigurationKeysForTextAnalytics(this TextAnalyticConfigurationSettings configSettings, string apiKey, LocationKeyIdentifier locationKey)
        {
            var config = new TextAnalyticConfigurationSettings(apiKey, locationKey);
            return config;
        }

    }
}
