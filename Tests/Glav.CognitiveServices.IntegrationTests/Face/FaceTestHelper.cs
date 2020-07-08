using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.IntegrationTests.Face
{
    public static class FaceTestHelper
    {
        public static FaceConfigurationSettings CreateFaceConfig()
        {
            return FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast, 6);
        }
    }
}
