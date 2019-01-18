using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public class FaceConfigurationSettings : ConfigurationSettings
    {
        public FaceConfigurationSettings(string apiKey, LocationKeyIdentifier locationKey) 
                : base(ApiActionCategory.Face,apiKey,locationKey, new ApiServiceUriCollection())
        {
        }

        public FaceConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        public static FaceConfigurationSettings CreateUsingConfigurationKeys(string apiKey, LocationKeyIdentifier locationKey)
        {
            return new FaceConfigurationSettings(apiKey, locationKey);
        }
    }
}
