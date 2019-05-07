using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupListResult : BaseApiResponseReturnsData<LargePersonGroupListResponseRoot, LargePersonGroupGetResponseItem[], BaseApiErrorResponse>
    {
        public LargePersonGroupListResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
            ResponseData = new LargePersonGroupListResponseRoot { LargePersonGroups = ParsingStrategy.ResponseData };
        }
    }

}
