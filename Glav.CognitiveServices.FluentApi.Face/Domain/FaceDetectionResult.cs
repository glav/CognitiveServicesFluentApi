using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class FaceDetectionResult : BaseResponseResult<FaceDetectResponseRoot>
    {
        public FaceDetectionResult(ICommunicationResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
            ParseResponseData();
        }

        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new FaceDetectResponseRoot
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
                    ResponseData = new FaceDetectResponseRoot { error = errorResponse };
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                var responseList = Newtonsoft.Json.JsonConvert.DeserializeObject<FaceDetectResponseItem[]>(ApiCallResult.Data);
                if (responseList == null)
                {
                    var apiError = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiErrorResponse>(ApiCallResult.Data);
                    if (apiError != null)
                    {
                        ResponseData = new FaceDetectResponseRoot { error = apiError };
                    }
                    ActionSubmittedSuccessfully = false;
                    return;
                }
                ResponseData = new FaceDetectResponseRoot { detectedFaces = responseList };
                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseData = new FaceDetectResponseRoot
                {
                    error = new ApiErrorResponse { code = StandardResponseCodes.ServerError, message = $"Error parsing results: {ex.Message}" }
                };
                ActionSubmittedSuccessfully = false;
            }
        }

    }
}
