using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class FaceDetectionServiceConfig : ApiServiceUriFragment
    {

        public override ApiActionCategory ApiCategory => ApiActionCategory.Face;

        public override string Template => "face/{0}/detect";

        public override string Version => ApiConstants.FACE_VERSION;
    }
}
