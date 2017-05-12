using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public static class ConfigurationBuilderExtensions
    {
        public static CoreAnalysisSettings UsingHttpCommunication(this ConfigurationSettings configSettings)
        {
            return new CoreAnalysisSettings(configSettings, new HttpCommunicationEngine(configSettings));
        }

        public static CoreAnalysisSettings UsingCustomCommunication(this ConfigurationSettings configSettings, ICommunicationEngine communicationEngine)
        {
            return new CoreAnalysisSettings(configSettings, communicationEngine);
        }
    }
}
