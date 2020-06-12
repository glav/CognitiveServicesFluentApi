using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Luis.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Luis.Domain
{
    public class LuisAppAnalysisResult : BaseApiResponseReturnsData<LuisAppResponseRoot, LuisAppResponseRoot, BaseApiErrorResponse>
    {
        public LuisAppAnalysisResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData = new LuisAppResponseRoot { error = ParsingStrategy.ResponseError };
                return;
            }
            ResponseData = ParsingStrategy.ResponseData;

            PerformCustomResponseParsing();

        }

        private void PerformCustomResponseParsing()
        {
            //TODO: Do the specialised parsing of response required for LUis response.
            throw new NotImplementedException();
        }
    }
}
