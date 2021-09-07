using Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using System;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class ReadImageAnalysisResult : BaseApiResponseReturnsData<VisionReadImageAnalysisResponseRoot, VisionReadImageAnalysisResponseRoot,RequestIdErrorResponse>
    {
        public ReadImageAnalysisResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData = new VisionReadImageAnalysisResponseRoot { error = ParsingStrategy.ResponseError };
                return;
            }
            ResponseData = ParsingStrategy.ResponseData;
        }
    }
}
