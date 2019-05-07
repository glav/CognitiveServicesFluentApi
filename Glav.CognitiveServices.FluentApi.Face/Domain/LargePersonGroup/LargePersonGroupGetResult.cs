using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupGetResult : BaseApiResponseWithStandardErrorReturnsData<LargePersonGroupGetResponseRoot, LargePersonGroupGetResponseRoot>
    {
        public LargePersonGroupGetResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData = new LargePersonGroupGetResponseRoot { error = ParsingStrategy.ResponseError };
                return;
            }
            ResponseData = ParsingStrategy.ResponseData;
        }
    }
    
}
