using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class LargePersonGroupPersonCreateServiceConfig : ApiServiceUriFragment
    {
        public override string Template => "face/{0}/largepersongroups";

        public override string Version => ApiConstants.FACE_VERSION;

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonCreate;
    }
    public class LargePersonGroupPersonListServiceConfig : ApiServiceUriFragment
    {

        public override string Template => "face/{0}/largepersongroups";

        public override string Version => ApiConstants.FACE_VERSION;

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonList;
    }
    public class LargePersonGroupPersonGetServiceConfig : ApiServiceUriFragment
    {

        public override string Template => "face/{0}/largepersongroups";

        public override string Version => ApiConstants.FACE_VERSION;

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonGet;
    }

    public class LargePersonGroupPersonDeleteServiceConfig : ApiServiceUriFragment
    {
        public override string Template => "face/{0}/largepersongroups";

        public override string Version => ApiConstants.FACE_VERSION;

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonDelete;
    }
    public class LargePersonGroupPersonFaceAddServiceConfig : ApiServiceUriFragment
    {
        public override string Template => "face/{0}/largepersongroups";

        public override string Version => ApiConstants.FACE_VERSION;

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonFaceAdd;
    }
    public class LargePersonGroupPersonFaceDeleteServiceConfig : ApiServiceUriFragment
    {
        public override string Template => "face/{0}/largepersongroups";

        public override string Version => ApiConstants.FACE_VERSION;

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonFaceDelete;
    }
    public class LargePersonGroupPersonFaceGetServiceConfig : ApiServiceUriFragment
    {
        public override string Template => "face/{0}/largepersongroups";

        public override string Version => ApiConstants.FACE_VERSION;

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonFaceGet;
    }
}
