using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public class ComputerVisionConfigurationSettings : ConfigurationSettings
    {
        public ComputerVisionConfigurationSettings(string apiKey, LocationKeyIdentifier locationKey) 
                : base(ApiActionCategory.ComputerVision,apiKey,locationKey, new ApiServiceUriCollection())
        {
        }

        public ComputerVisionConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        public static ComputerVisionConfigurationSettings CreateUsingConfigurationKeys(string apiKey, LocationKeyIdentifier locationKey)
        {
            return new ComputerVisionConfigurationSettings(apiKey, locationKey);
        }
    }
}
