using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonDeleteResult : BaseApiResponseReturnsData<LargePersonGroupPersonDeleteResponseRoot, LargePersonGroupPersonDeleteResponseRoot>
    {
        public LargePersonGroupPersonDeleteResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
        }
    }
}
