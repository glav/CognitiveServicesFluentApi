using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses
{
    public class ApiErrorResponse : BaseApiErrorResponse
    {
        public long id { get; set; }
        public BaseApiErrorResponse InnerError { get; set; }
    }
}
