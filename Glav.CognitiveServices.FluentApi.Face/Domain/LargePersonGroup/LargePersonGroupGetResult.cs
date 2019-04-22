using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupGetResult : BaseApiResponseReturnsData<LargePersonGroupGetResponseRoot, LargePersonGroupGetResponseItem>
    {
        public LargePersonGroupGetResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
            ResponseData = new LargePersonGroupGetResponseRoot { LargePersonGroup = ParsingStrategy.ResponseItemData};
        }
    }
    
}
