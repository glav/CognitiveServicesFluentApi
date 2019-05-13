using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.Parsing
{
    public class TextAnalyticParsingStrategy<TResponseRoot, TResponseItem> : CallReturnsDataParsingStrategy<TResponseRoot, ApiErrorResponse>
        where TResponseRoot : BaseResponse<TResponseItem>
        where TResponseItem : class
    {
        public override void ParseApiCall(ICommunicationResult apiCallResult)
        {
            base.ParseApiCall(apiCallResult);
            if (ResponseData == null || ResponseData.documents == null)
            {
                var errors = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiErrorResponse>(apiCallResult.Data);
                if (errors != null)
                {
                    ResponseError =  errors ;
                } else
                {
                    SetStandardError(StandardResponseCodes.NoDataParsed, StandardResponseCodes.NoDataParsedMessage);
                }
                ActionSubmittedSuccessfully = false;
            }
        }
    }
}
