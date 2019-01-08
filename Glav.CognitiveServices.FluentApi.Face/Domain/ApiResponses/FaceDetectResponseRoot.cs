using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class FaceDetectResponseRoot : IActionResponseRoot
    {
        public ApiErrorResponse error { get; set; }
    }

}
