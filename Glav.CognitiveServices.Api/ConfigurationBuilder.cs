using Glav.CognitiveServices.Api.Communication;
using Glav.CognitiveServices.Api.Configuration;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.Api
{
    public static class ConfigurationBuilder
    {
        public static ConfigurationSettings CreateUsingApiKey(string apiKey)
        {
            var config = new ConfigurationSettings(apiKey);
            return config;
        }

        public static ApiAnalysisSettings UsingHttpCommunication(this ConfigurationSettings configSettings)
        {
            return new ApiAnalysisSettings(configSettings, new CommunicationEngine(configSettings));
        }

        public static ApiAnalysisSettings UsingCustomCommunication(this ConfigurationSettings configSettings, ICommunicationEngine communicationEngine)
        {
            return new ApiAnalysisSettings(configSettings, communicationEngine);
        }

        public static async Task<ApiAnalysisResults> AnalyseAllAsync(this ApiAnalysisSettings apiAnalysisSettings)
        {
            var engine = new AnalysisEngine(apiAnalysisSettings);
            return await engine.AnalyseAllAsync();
        }

    }
}
