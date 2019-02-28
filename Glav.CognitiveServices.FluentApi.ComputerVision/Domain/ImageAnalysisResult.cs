using Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class ImageAnalysisResult : BaseResponseResult<VisionImageAnalysisResponseRoot>
    {
        public ImageAnalysisResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
        }

        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new VisionImageAnalysisResponseRoot
                {
                    error = new ApiErrorResponse
                    {
                        code = StandardResponseCodes.NoDataReturned,
                        message = StandardResponseCodes.NoDataReturnedMessage
                    }
                };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                if ((int)ApiCallResult.StatusCode >= 400)
                {
                    var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiErrorResponse>(ApiCallResult.Data);
                    ResponseData = new VisionImageAnalysisResponseRoot { error = errorResponse };
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<VisionImageAnalysisResponseRoot>(ApiCallResult.Data);
                if (ResponseData == null)
                {
                    var apiError = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiErrorResponse>(ApiCallResult.Data);
                    if (apiError != null)
                    {
                        ResponseData = new VisionImageAnalysisResponseRoot { error =  apiError };
                    }
                    ActionSubmittedSuccessfully = false;
                    return;
                }
                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseData = new VisionImageAnalysisResponseRoot
                {
                    error = new ApiErrorResponse
                    {
                        code = StandardResponseCodes.ServerError,
                        message = $"Error parsing results: {ex.Message}"
                    }
                };
                ActionSubmittedSuccessfully = false;
            }
        }

    }
}
