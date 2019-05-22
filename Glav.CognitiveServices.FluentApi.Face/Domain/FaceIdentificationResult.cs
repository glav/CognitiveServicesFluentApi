using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class FaceIdentificationResult : BaseApiResponseReturnsData<FaceIdentifyResponseRoot, FaceIdentifyResponseItem[], FaceIdentifyResponseRoot>
    {
        public FaceIdentificationResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData = ParsingStrategy.ResponseError;
                return;
            }
            ResponseData = new FaceIdentifyResponseRoot { identifiedFaces = ParsingStrategy.ResponseData };
        }
    }
}
