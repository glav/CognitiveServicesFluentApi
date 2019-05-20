using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class FaceIdentifyResponseRoot : IActionResponseRootWithError
    {
        public BaseApiErrorResponse error { get; set; }
        public FaceIdentifyResponseItem[] identifiedFaces { get; set; }
    }

}
