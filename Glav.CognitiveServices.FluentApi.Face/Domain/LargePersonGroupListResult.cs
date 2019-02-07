using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class LargePersonGroupListResult : BaseResponseResult<LargePersonGroupListResponseRoot>
    {
        public LargePersonGroupListResult(ICommunicationResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
            ParseResponseData();
        }

        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new LargePersonGroupListResponseRoot
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
                    ResponseData = new LargePersonGroupListResponseRoot { error = errorResponse };
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<LargePersonGroupGetResponseItem[]>(ApiCallResult.Data);
                if (responseData == null)
                {
                    var apiError = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiErrorResponse>(ApiCallResult.Data);
                    if (apiError != null)
                    {
                        ResponseData = new LargePersonGroupListResponseRoot { error = apiError };
                    }
                    ActionSubmittedSuccessfully = false;
                    return;
                }
                ResponseData = new LargePersonGroupListResponseRoot { LargePersonGroups = responseData };
                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseData = new LargePersonGroupListResponseRoot
                {
                    error = new ApiErrorResponse { code = StandardResponseCodes.ServerError, message = $"Error parsing results: {ex.Message}" }
                };
                ActionSubmittedSuccessfully = false;
            }
        }

    }
}
