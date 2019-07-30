using Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using System;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class OcrAnalysisResult : BaseApiResponseReturnsData<VisionOCRAnalysisResponseRoot, VisionOCRAnalysisResponseRoot, RequestIdErrorResponse>
    {
        public OcrAnalysisResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData = new VisionOCRAnalysisResponseRoot { error = ParsingStrategy.ResponseError };
                return;
            }
            ResponseData = ParsingStrategy.ResponseData;
        }
    }
}
