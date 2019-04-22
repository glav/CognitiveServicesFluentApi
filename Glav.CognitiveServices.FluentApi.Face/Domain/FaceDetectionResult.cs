using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class FaceDetectionResult : BaseApiResponseReturnsData<FaceDetectResponseRoot, FaceDetectResponseItem[]>
    {
        public FaceDetectionResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
            ResponseData = new FaceDetectResponseRoot { detectedFaces = ParsingStrategy.ResponseItemData };
        }
    }
}
