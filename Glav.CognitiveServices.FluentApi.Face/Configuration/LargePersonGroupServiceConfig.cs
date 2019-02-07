using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class LargePersonGroupCreateServiceConfig : ApiServiceUriFragment
    {

        public override string Template => "face/{0}/largepersongroups";

        public override string Version => ApiConstants.FACE_VERSION;

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupCreate;
    }
    public class LargePersonGroupListServiceConfig : ApiServiceUriFragment
    {

        public override string Template => "face/{0}/largepersongroups";

        public override string Version => ApiConstants.FACE_VERSION;

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupList;
    }
    public class LargePersonGroupGetServiceConfig : ApiServiceUriFragment
    {

        public override string Template => "face/{0}/largepersongroups";

        public override string Version => ApiConstants.FACE_VERSION;

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupGet;
    }

}
