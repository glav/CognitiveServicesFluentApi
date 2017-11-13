using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class ApiErrorResponse
    {
        public string code { get; set; }
        public string requestId { get; set; }
        public string message { get; set; }
    }
}
