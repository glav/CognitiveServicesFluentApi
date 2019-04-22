using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class LargePersonGroupPersonFaceGetResponseRoot : IActionResponseRootWithError
    {
        public string persistedFaceId { get; set; }
        public string userData { get; set; }
        public BaseApiErrorResponse error { get; set; }
    }


}
