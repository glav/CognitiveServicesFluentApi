using Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using System;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class ImageAnalysisResult : BaseApiResponseReturnsData<VisionImageAnalysisResponseRoot, VisionImageAnalysisResponseRoot, RequestIdErrorResponse>
    {
        public ImageAnalysisResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
            if (!ActionSubmittedSuccessfully)
            {
                ResponseData = new VisionImageAnalysisResponseRoot { error = ParsingStrategy.ResponseError };
                return;
            }
            ResponseData = ParsingStrategy.ResponseData;
        }
        /*
        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new VisionImageAnalysisResponseRoot
                {
                    error = new RequestIdErrorResponse
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
                    var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestIdErrorResponse>(ApiCallResult.Data);
                    ResponseData = new VisionImageAnalysisResponseRoot { error = errorResponse };
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<VisionImageAnalysisResponseRoot>(ApiCallResult.Data);
                if (ResponseData == null)
                {
                    var apiError = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestIdErrorResponse>(ApiCallResult.Data);
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
                    error = new RequestIdErrorResponse
                    {
                        code = StandardResponseCodes.ServerError,
                        message = $"Error parsing results: {ex.Message}"
                    }
                };
                ActionSubmittedSuccessfully = false;
            }
        }
        */

    }
}
