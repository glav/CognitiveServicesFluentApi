using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public class FaceConfigurationSettings : ConfigurationSettings
    {
        public FaceConfigurationSettings(string apiKey, LocationKeyIdentifier locationKey, int maxNumberOfRequestRetries = Core.Configuration.ApiConstants.DefaultMaxNumberOfRequestRetries) 
                : base(FaceApiOperations.Category,apiKey,locationKey, new ApiServiceUriCollection(),maxNumberOfRequestRetries)
        {
        }

        public FaceConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        public static FaceConfigurationSettings CreateUsingConfigurationKeys(string apiKey, LocationKeyIdentifier locationKey, int maxNumberOfRequestRetries = Core.Configuration.ApiConstants.DefaultMaxNumberOfRequestRetries)
        {
            SupportedLanguages.Setup();
            return new FaceConfigurationSettings(apiKey, locationKey, maxNumberOfRequestRetries);
        }
    }
}
