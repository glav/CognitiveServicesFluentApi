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
        public FaceConfigurationSettings(string apiKey, LocationKeyIdentifier locationKey, string apiVersionIdentifier = Configuration.ApiConstants.DEFAULT_FACE_VERSION,
                                        int maxNumberOfRequestRetries = Core.Configuration.ApiConstants.DefaultMaxNumberOfRequestRetries) 
                : base(FaceApiOperations.Category,apiKey,locationKey, new ApiServiceUriCollection(apiVersionIdentifier),maxNumberOfRequestRetries)
        {
        }

        public FaceConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        public static FaceConfigurationSettings CreateUsingConfigurationKeys(string apiKey, LocationKeyIdentifier locationKey, string apiVersionIdentifier = Configuration.ApiConstants.DEFAULT_FACE_VERSION,
                                                                        int maxNumberOfRequestRetries = Core.Configuration.ApiConstants.DefaultMaxNumberOfRequestRetries)
        {
            SupportedLanguages.Setup();
            return new FaceConfigurationSettings(apiKey, locationKey,apiVersionIdentifier, maxNumberOfRequestRetries);
        }
    }
}
