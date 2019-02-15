using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class FaceDetectResponseRoot : IActionResponseRoot
    {
        public BaseApiErrorResponse error { get; set; }
        public FaceDetectResponseItem[] detectedFaces { get; set; }
    }

}
