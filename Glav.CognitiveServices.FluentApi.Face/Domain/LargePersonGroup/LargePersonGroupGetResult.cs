using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupGetResult : BaseApiResponseReturnsData<LargePersonGroupGetResponseRoot, LargePersonGroupGetResponseItem, LargePersonGroupGetResponseRoot>
    {
        public LargePersonGroupGetResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData =ParsingStrategy.ResponseError;
                return;
            }
            ResponseData = new LargePersonGroupGetResponseRoot { LargePersonGroup = ParsingStrategy.ResponseData };
        }
    }
    
}
