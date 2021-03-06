﻿using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public class ComputerVisionConfigurationSettings : ConfigurationSettings
    {
        public ComputerVisionConfigurationSettings(string apiKey, LocationKeyIdentifier locationKey) 
                : base(ComputerVisionApiOperations.Category,apiKey,locationKey, new ApiServiceUriCollection())
        {
        }

        public ComputerVisionConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        public static ComputerVisionConfigurationSettings CreateUsingConfigurationKeys(string apiKey, LocationKeyIdentifier locationKey)
        {
            SupportedLanguages.Setup();
            return new ComputerVisionConfigurationSettings(apiKey, locationKey);
        }
    }
}
