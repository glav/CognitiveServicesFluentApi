using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class LargePersonGroupCreateResponseRoot : IActionResponseRoot
    {
        public ApiErrorResponse error { get; set; }
    }

}
