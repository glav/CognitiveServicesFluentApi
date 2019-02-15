using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class ApiErrorResponse : BaseApiErrorResponse
    {
        public string requestId { get; set; }

    }
}
