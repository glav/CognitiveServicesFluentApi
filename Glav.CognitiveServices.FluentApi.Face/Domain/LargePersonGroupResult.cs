using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class LargePersonGroupResult : BaseResponseResult<LargePersonGroupResponseRoot>
    {
        public LargePersonGroupResult(ICommunicationResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
            ParseResponseData();
        }

        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new LargePersonGroupResponseRoot
                {
                    error = new ApiErrorResponse { code = StandardResponseCodes.NoDataReturned, message = "No data returned." }
                };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                if ((int)ApiCallResult.StatusCode >= 400)
                {
                    var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiErrorResponse>(ApiCallResult.Data);
                    ResponseData = new LargePersonGroupResponseRoot { error = errorResponse };
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseData = new LargePersonGroupResponseRoot
                {
                    error = new ApiErrorResponse { code = StandardResponseCodes.ServerError, message = $"Error parsing results: {ex.Message}" }
                };
                ActionSubmittedSuccessfully = false;
            }
        }

    }
}
