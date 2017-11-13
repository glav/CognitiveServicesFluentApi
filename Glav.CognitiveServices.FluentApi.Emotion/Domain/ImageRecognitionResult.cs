using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Emotion.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain
{
    public sealed class ImageRecognitionResult : BaseResponseResult<EmotionImageRecognitionResponseRoot>
    {
        public ImageRecognitionResult(ICommunicationResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
            ParseResponseData();
        }

        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new EmotionImageRecognitionResponseRoot
                {
                    error = new ApiErrorResponse
                    {
                        code = StandardResponseCodes.NoDataReturned,
                        message = "No data returned."
                    }
                };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                if (ApiCallResult.StatusCode == System.Net.HttpStatusCode.OK || ApiCallResult.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    var responseList = Newtonsoft.Json.JsonConvert.DeserializeObject<EmotionImageRecognitionResponseItem[]>(ApiCallResult.Data);
                    if (responseList == null)
                    {
                        ActionSubmittedSuccessfully = false;
                        return;
                    }
                    ResponseData = new EmotionImageRecognitionResponseRoot { faces = responseList };
                    ActionSubmittedSuccessfully = true;
                    return;
                }

                //TODO: Need to double check this logic. On revisiting, it does not look right.
                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<EmotionImageRecognitionResponseRoot>(ApiCallResult.Data);
                ActionSubmittedSuccessfully = false;

            }
            catch (Exception ex)
            {
                ResponseData = new EmotionImageRecognitionResponseRoot
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
