using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public class ComputerVisionConfigurationSettings : ConfigurationSettings
    {
        public ComputerVisionConfigurationSettings(string apiKey, LocationKeyIdentifier locationKey, string apiVersionIdentifier=Configuration.ApiConstants.DEFAULT_ComputerVisionVersion) 
                : base(ComputerVisionApiOperations.Category,apiKey,locationKey, new ApiServiceUriCollection(apiVersionIdentifier))
        {
        }

        public ComputerVisionConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        public static ComputerVisionConfigurationSettings CreateUsingConfigurationKeys(string apiKey, LocationKeyIdentifier locationKey, 
            string apiVersionIdentifier = Configuration.ApiConstants.DEFAULT_ComputerVisionVersion)
        {
            SupportedLanguages.Setup();
            return new ComputerVisionConfigurationSettings(apiKey, locationKey,apiVersionIdentifier);
        }
    }
}
