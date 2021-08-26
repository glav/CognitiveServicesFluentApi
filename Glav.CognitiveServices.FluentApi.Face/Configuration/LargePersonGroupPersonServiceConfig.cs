using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class LargePersonGroupPersonCreateServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupPersonCreateServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonCreate;
    }
    public class LargePersonGroupPersonListServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupPersonListServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }

        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonList;
    }
    public class LargePersonGroupPersonGetServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupPersonGetServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }

        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonGet;
    }

    public class LargePersonGroupPersonDeleteServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupPersonDeleteServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonDelete;
    }
    public class LargePersonGroupPersonFaceAddServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupPersonFaceAddServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonFaceAdd;
    }
    public class LargePersonGroupPersonFaceDeleteServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupPersonFaceDeleteServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonFaceDelete;
    }
    public class LargePersonGroupPersonFaceGetServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupPersonFaceGetServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupPersonFaceGet;
    }
}
