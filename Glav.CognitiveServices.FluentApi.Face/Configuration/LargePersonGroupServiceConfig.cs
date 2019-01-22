using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class LargePersonGroupServiceConfig : ApiServiceUriFragment
    {

        public override ApiActionCategory ApiCategory => ApiActionCategory.Face;

        public override string Template => "face/{0}/largepersongroups";

        public override string Version => ApiConstants.FACE_VERSION;
    }
}
