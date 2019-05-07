using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupTrainStatusResult : BaseApiResponseWithStandardErrorReturnsData<LargePersonGroupTrainStatusResponseRoot, LargePersonGroupTrainStatusResponseItem>
    {
        public LargePersonGroupTrainStatusResult(ICommunicationResult apiCallResult): base(apiCallResult)
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData = new LargePersonGroupTrainStatusResponseRoot { error = ParsingStrategy.ResponseError };
                return;
            }
            ResponseData = new LargePersonGroupTrainStatusResponseRoot { TrainingStatus = ParsingStrategy.ResponseData };
        }
    }
}
