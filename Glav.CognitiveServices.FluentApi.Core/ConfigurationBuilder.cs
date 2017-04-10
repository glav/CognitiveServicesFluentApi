using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Core
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


    }
}
