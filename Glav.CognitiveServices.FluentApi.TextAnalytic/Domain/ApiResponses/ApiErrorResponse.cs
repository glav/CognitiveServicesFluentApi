using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses
{
    public class ApiErrorResponse : ErrorResponse
    {
        public long id { get; set; }
    }

    public class ErrorResponse : BaseErrorResponseCode
    {
        public BaseErrorResponseCode InnerError { get; set; }
    }

    public class BaseErrorResponseCode
    {
        public string code { get; set; }
        public string message { get; set; }

    }
}
