using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class FaceDetectionServiceConfig : ApiServiceUriFragment
    {
        public FaceDetectionServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "face/{0}/detect";

        public override ApiActionDefinition ApiAction => FaceApiOperations.FaceDetection;
    }
}
