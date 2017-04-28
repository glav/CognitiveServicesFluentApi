using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Emotion.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain
{
    public sealed class EmotionImageRecognitionResult : IApiAnalysisResult<EmotionImageRecognitionResponseRoot>
    {
        public EmotionImageRecognitionResult(ICommunicationResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
            ParseResponseData();
        }

        public EmotionImageRecognitionResponseRoot ResponseData { get; private set; }

        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new EmotionImageRecognitionResponseRoot { error = new ApiErrorResponse { statusCode = 400, message = "No data returned." } };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<EmotionImageRecognitionResponseRoot>(ApiCallResult.Data);
                if (ResponseData == null || ResponseData.error != null)
                {
                    ActionSubmittedSuccessfully = false;
                    return;
                }
                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseData = new EmotionImageRecognitionResponseRoot { error =  new ApiErrorResponse { statusCode = 500, message = $"Error parsing results: {ex.Message}" } };
                ActionSubmittedSuccessfully = false;
            }
        }

        public bool ActionSubmittedSuccessfully { get; private set; }

        public ICommunicationResult ApiCallResult { get; private set; }
    }
}
