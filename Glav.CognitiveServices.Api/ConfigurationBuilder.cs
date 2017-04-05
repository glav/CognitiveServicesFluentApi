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

        public static AnalysisSettings UsingHttpCommunication(this ConfigurationSettings configSettings)
        {
            return new AnalysisSettings(configSettings, new CommunicationEngine(configSettings));
        }

        public static AnalysisSettings UsingCustomCommunication(this ConfigurationSettings configSettings, ICommunicationEngine communicationEngine)
        {
            return new AnalysisSettings(configSettings, communicationEngine);
        }

        public static async Task<AnalysisResults> AnalyseAllAsync(this AnalysisSettings apiAnalysisSettings)
        {
            var engine = new AnalysisEngine(apiAnalysisSettings);
            return await engine.AnalyseAllAsync();
        }

    }
}
