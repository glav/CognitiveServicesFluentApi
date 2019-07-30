using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonFaceGetResult : BaseApiResponseReturnsData<LargePersonGroupPersonFaceGetResponseRoot, LargePersonGroupPersonFaceGetResponseRoot, LargePersonGroupPersonFaceGetResponseRoot>
    {
        public LargePersonGroupPersonFaceGetResult(ICommunicationResult apiCallResult) : base(apiCallResult)
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
