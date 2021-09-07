using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class LargePersonGroupCreateServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupCreateServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupCreate;
    }
    public class LargePersonGroupListServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupListServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupList;
    }
    public class LargePersonGroupTrainStartServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupTrainStartServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupTrainStart;
    }

    public class LargePersonGroupTrainStatusServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupTrainStatusServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupTrainStatus;
    }
    class LargePersonGroupGetServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupGetServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupGet;
    }

    public class LargePersonGroupDeleteServiceConfig : ApiServiceUriFragment
    {
        public LargePersonGroupDeleteServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "face/{0}/largepersongroups";

        public override ApiActionDefinition ApiAction => FaceApiOperations.LargePersonGroupDelete;
    }

}
