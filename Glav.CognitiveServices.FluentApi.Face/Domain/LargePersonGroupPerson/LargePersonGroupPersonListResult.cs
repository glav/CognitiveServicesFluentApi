using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonListResult : BaseApiResponseReturnsData<LargePersonGroupPersonListResponseRoot, LargePersonGroupPersonGetResponseItem[], LargePersonGroupPersonListResponseRoot>
    {
        public LargePersonGroupPersonListResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData = ParsingStrategy.ResponseError;
                return;
            }
            ResponseData = new LargePersonGroupPersonListResponseRoot { LargePersonGroupPersons = ParsingStrategy.ResponseData };
        }

    }
}
