using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class FaceIdentificationServiceConfig : ApiServiceUriFragment
    {
        public FaceIdentificationServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }

        public override string Template => "face/{0}/identify";

        public override ApiActionDefinition ApiAction => FaceApiOperations.FaceIdentification;
    }
}
