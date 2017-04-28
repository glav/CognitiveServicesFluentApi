using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain.ApiResponses
{
    public class ApiErrorResponse
    {
        public int statusCode { get; set; }
        public string message { get; set; }
    }
}
