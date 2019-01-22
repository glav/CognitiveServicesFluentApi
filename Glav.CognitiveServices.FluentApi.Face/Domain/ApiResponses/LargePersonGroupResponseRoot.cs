using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class LargePersonGroupResponseRoot : IActionResponseRoot
    {
        public ApiErrorResponse error { get; set; }
    }

}
