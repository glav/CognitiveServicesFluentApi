using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class LargePersonGroupPersonFaceDeleteResponseRoot : IActionResponseRoot
    {
        public BaseApiErrorResponse error { get; set; }
    }

}
