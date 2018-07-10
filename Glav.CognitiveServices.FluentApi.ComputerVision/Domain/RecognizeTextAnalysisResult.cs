﻿using Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class RecognizeTextAnalysisResult : BaseResponseResult<VisionRecognizeTextAnalysisResponseRoot>
    {
        public RecognizeTextAnalysisResult(ICommunicationResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
            ParseResponseData();
        }

        private void ParseResponseData()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new VisionRecognizeTextAnalysisResponseRoot
                {
                    error = ApiErrorResponse.CreateResponse(StandardResponseCodes.NoDataReturned, "No data returned.")
                };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                if ((int)ApiCallResult.StatusCode >= 400)
                {
                    var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiErrorResponse>(ApiCallResult.Data);
                    ResponseData = new VisionRecognizeTextAnalysisResponseRoot { error = errorResponse };
                    ActionSubmittedSuccessfully = false;
                    return;
                }

                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<VisionRecognizeTextAnalysisResponseRoot>(ApiCallResult.Data);
                if (ResponseData == null)
                {
                    ActionSubmittedSuccessfully = false;
                    return;
                }
                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseData = new VisionRecognizeTextAnalysisResponseRoot
                {
                    error = ApiErrorResponse.CreateResponse(StandardResponseCodes.ServerError,$"Error parsing results: {ex.Message}")
                };
                ActionSubmittedSuccessfully = false;
            }
        }

    }
}
