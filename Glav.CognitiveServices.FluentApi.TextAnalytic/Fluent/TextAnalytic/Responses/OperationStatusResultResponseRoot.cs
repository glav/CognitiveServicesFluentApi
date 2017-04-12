using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.TextAnalytic.Responses
{
    public class OperationStatusResultResponseRoot : IActionResponseRoot
    {
        public string status { get; set; }
        public string createdDateTime { get; set; }
        public string lastActionDateTime { get; set; }
        public string operationType { get; set; }
        public TextAnalyticOperationProcessingResult operationProcessingResult { get; set; }
        public string discriminator { get; set; }
        public string message { get; set; }
    }

    public class TextAnalyticOperationProcessingResult
    {
        public ApiErrorResponse[] errors { get; set; }
    }
}
