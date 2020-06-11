using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Luis.Domain.ApiResponses
{
    public class LuisAppResponseRoot : IActionResponseRootWithError
    {
        public BaseApiErrorResponse error { get; set; }
        public string query { get; set; }
    }
}