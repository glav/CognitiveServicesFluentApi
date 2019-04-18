using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupDeleteResult : BaseResponseResulNoDatatWithStrategy<LargePersonGroupDeleteResponseRoot>
    {
        public LargePersonGroupDeleteResult(ICommunicationResult apiCallResult)
            : base(apiCallResult, new CallReturnsNoDataParsingStrategy<LargePersonGroupDeleteResponseRoot>())
        {
            ParseResponseData();
       }
        

        
    }
    /*
    public class LargePersonGroupDeleteResult : BaseResponseResult<LargePersonGroupDeleteResponseRoot>
    {
        public LargePersonGroupDeleteResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
        }

        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new LargePersonGroupDeleteResponseRoot
                {
                    error = new BaseApiErrorResponse { code = StandardResponseCodes.NoDataReturned, message = StandardResponseCodes.NoDataReturnedMessage }
                };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                if ((int)ApiCallResult.StatusCode >= 400)
                {
                    var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseApiErrorResponse>(ApiCallResult.Data);
                    ResponseData = new LargePersonGroupDeleteResponseRoot { error = errorResponse };
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseData = new LargePersonGroupDeleteResponseRoot
                {
                    error = new BaseApiErrorResponse { code = StandardResponseCodes.ServerError, message = $"Error parsing results: {ex.Message}" }
                };
                ActionSubmittedSuccessfully = false;
            }
        }

    }
    */
}
