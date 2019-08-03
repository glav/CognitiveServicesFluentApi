using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses
{
    public class CatchAllError : BaseApiErrorResponse
    {
        public BaseApiErrorResponse error { get; set; }
        public BaseApiErrorResponse innerError { get; set; }
    }
}
