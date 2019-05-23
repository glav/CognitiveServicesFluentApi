using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonGetResult : BaseApiResponseReturnsData<LargePersonGroupPersonGetResponseRoot, LargePersonGroupPersonGetResponseItem, LargePersonGroupPersonGetResponseRoot>
    {
        public LargePersonGroupPersonGetResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData = ParsingStrategy.ResponseError;
                return;
            }
            ResponseData = new LargePersonGroupPersonGetResponseRoot { LargePersonGroupPerson = ParsingStrategy.ResponseData };
        }

    }
}
