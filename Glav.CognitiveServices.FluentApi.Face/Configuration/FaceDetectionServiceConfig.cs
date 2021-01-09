using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class FaceDetectionServiceConfig : ApiServiceUriFragment
    {

        public override string Template => "face/{0}/detect";

        public override string Version => ApiConstants.DEFAULT_FACE_VERSION;

        public override ApiActionDefinition ApiAction => FaceApiOperations.FaceDetection;
    }
}
