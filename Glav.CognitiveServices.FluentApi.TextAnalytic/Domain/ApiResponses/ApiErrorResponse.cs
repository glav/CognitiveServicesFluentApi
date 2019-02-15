using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses
{
    public class ApiErrorResponse : ErrorResponse
    {
        public long id { get; set; }
    }

    public class ErrorResponse : BaseApiErrorResponse
    {
        public BaseApiErrorResponse InnerError { get; set; }
    }
}
