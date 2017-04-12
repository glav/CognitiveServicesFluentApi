using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent
{
    public static class ConfigurationBuilderExtensions
    {
        public static ConfigurationSettings CreateUsingApiKeyForTextAnalytics(string apiKey)
        {
            var config = new TextAnalyticConfigurationSettings(apiKey, new ApiServiceUrlFragments());
            return config;
        }

    }
}
