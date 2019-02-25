using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonFaceAddResult : BaseResponseResult<LargePersonGroupPersonFaceAddResponseRoot>
    {
        public LargePersonGroupPersonFaceAddResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
        }

        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new LargePersonGroupPersonFaceAddResponseRoot
                {
                    error = new BaseApiErrorResponse { code = StandardResponseCodes.NoDataReturned, message = "No data returned." }
                };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                if ((int)ApiCallResult.StatusCode >= 400)
                {
                    var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseApiErrorResponse>(ApiCallResult.Data);
                    ResponseData = new LargePersonGroupPersonFaceAddResponseRoot { error = errorResponse };
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<LargePersonGroupPersonFaceAddResponseRoot>(ApiCallResult.Data);
                if (responseData == null)
                {
                    var apiError = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseApiErrorResponse>(ApiCallResult.Data);
                    if (apiError != null)
                    {
                        ResponseData = new LargePersonGroupPersonFaceAddResponseRoot { error = apiError };
                    }
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                ResponseData = responseData;
                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseData = new LargePersonGroupPersonFaceAddResponseRoot
                {
                    error = new BaseApiErrorResponse { code = StandardResponseCodes.ServerError, message = $"Error parsing results: {ex.Message}" }
                };
                ActionSubmittedSuccessfully = false;
            }
        }

    }
}
