using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Emotion.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain
{
    public sealed class ImageRecognitionResult : IApiRequestResult<EmotionImageRecognitionResponseRoot>
    {
        public ImageRecognitionResult(ICommunicationResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
            ParseResponseData();
        }

        public EmotionImageRecognitionResponseRoot ResponseData { get; private set; }

        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new EmotionImageRecognitionResponseRoot { error = new ApiErrorResponse { code = "BadRequest", message = "No data returned." } };
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

                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<EmotionImageRecognitionResponseRoot>(ApiCallResult.Data);
                ActionSubmittedSuccessfully = false;

            }
            catch (Exception ex)
            {
                ResponseData = new EmotionImageRecognitionResponseRoot { error = new ApiErrorResponse { code = "ServerError", message = $"Error parsing results: {ex.Message}" } };
                ActionSubmittedSuccessfully = false;
            }
        }

        public bool ActionSubmittedSuccessfully { get; private set; }

        public ICommunicationResult ApiCallResult { get; private set; }
    }
}
