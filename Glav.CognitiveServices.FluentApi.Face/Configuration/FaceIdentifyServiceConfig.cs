using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class FaceIdentifyServiceConfig : ApiServiceUriFragment
    {

        public override string Template => "face/{0}/identify";

        public override string Version => ApiConstants.FACE_VERSION;

        public override ApiActionDefinition ApiAction => FaceApiOperations.FaceDetection;
    }
}
