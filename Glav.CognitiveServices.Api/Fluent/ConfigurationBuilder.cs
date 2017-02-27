using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public static class ConfigurationBuilder
    {
        public static ApiAnalysisSettings CreateUsingApiKey(string apiKey)
        {
            var config = new ConfigurationSettings(apiKey);
            return new ApiAnalysisSettings(config);
        }

        public static ApiAnalysisResults Analyse(this ApiAnalysisSettings apiAnalysisSettings)
        {
            var factory = new AnalysisFactory(apiAnalysisSettings);
            return factory.Analyse();
        }
    }
}
