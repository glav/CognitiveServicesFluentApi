using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses
{
    public class OperationStatusResultResponseRoot : IActionResponseRoot
    {
        public string status { get; set; }
        public string createdDateTime { get; set; }
        public string lastActionDateTime { get; set; }
        public string operationType { get; set; }
        public TextAlayticOperationProcessingResult operationProcessingResult { get; set; }
        public string discriminator { get; set; }
        public string message { get; set; }
    }

    public class TextAlayticOperationProcessingResult
    {
        public ApiErrorResponse[] errors { get; set; }
    }
}
