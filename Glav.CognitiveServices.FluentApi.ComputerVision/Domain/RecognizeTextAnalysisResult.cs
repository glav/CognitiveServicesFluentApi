using Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using System;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class RecognizeTextAnalysisResult : BaseApiResponse<VisionRecognizeTextAnalysisResponseRoot>
    {
        public RecognizeTextAnalysisResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            ParseResponseData();
        }

        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new VisionRecognizeTextAnalysisResponseRoot
                {
                    error = new RequestIdErrorResponse { code = StandardResponseCodes.NoDataReturned, message = StandardResponseCodes.NoDataReturnedMessage }
                };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                if ((int)ApiCallResult.StatusCode >= 400)
                {
                    var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestIdErrorResponse>(ApiCallResult.Data);
                    ResponseData = new VisionRecognizeTextAnalysisResponseRoot { error = errorResponse };
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                if (ApiCallResult.StatusCode == System.Net.HttpStatusCode.Accepted && ApiCallResult.OperationLocationUri != null)
                {
                    ActionSubmittedSuccessfully = true;
                    return;
                }

                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<VisionRecognizeTextAnalysisResponseRoot>(ApiCallResult.Data);
                if (ResponseData == null)
                {
                    var apiError = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestIdErrorResponse>(ApiCallResult.Data);
                    if (apiError != null)
                    {
                        ResponseData = new VisionRecognizeTextAnalysisResponseRoot { error = apiError };
                    }
                    ActionSubmittedSuccessfully = false;
                    return;
                }
                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseData = new VisionRecognizeTextAnalysisResponseRoot
                {
                    error = new RequestIdErrorResponse { code = StandardResponseCodes.ServerError, message = $"Error parsing results: {ex.Message}" }
                };
                ActionSubmittedSuccessfully = false;
            }
        }

    }
}
