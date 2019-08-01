using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonFaceAddResult : BaseApiResponseWithStrategy<LargePersonGroupPersonFaceAddResponseRoot, LargePersonGroupPersonFaceAddResponseRoot, LargePersonGroupPersonFaceAddResponseRoot>
    {
        public LargePersonGroupPersonFaceAddResult(ICommunicationResult apiCallResult) : base(apiCallResult,
            new CallReturnsDataParsingStrategy<LargePersonGroupPersonFaceAddResponseRoot, LargePersonGroupPersonFaceAddResponseRoot>())
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData = ParsingStrategy.ResponseError;
                return;
            }
            ResponseData = ParsingStrategy.ResponseData;
        }

    }
}
