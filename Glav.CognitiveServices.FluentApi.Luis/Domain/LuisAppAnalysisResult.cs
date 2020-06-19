using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.Luis.Domain.ApiResponses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Luis.Domain
{
    public class LuisAppAnalysisResult : BaseApiResponse<LuisAppResponseRoot>
    {
        public LuisAppAnalysisResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            PerformCustomResponseParsing();
        }

        private void PerformCustomResponseParsing()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new LuisAppResponseRoot { error = new BaseApiErrorResponse { message = StandardResponseCodes.NoDataReturnedMessage } };
                ActionSubmittedSuccessfully = false;
                return;
            }

            if (((int)ApiCallResult.StatusCode) >= (int)HttpStatusCode.BadRequest || !ApiCallResult.Successfull)
            {
                ActionSubmittedSuccessfully = false;

                ResponseData = new LuisAppResponseRoot { error = new BaseApiErrorResponse { code= ApiCallResult.StatusCode.ToString(), message = ApiCallResult.ErrorMessage } };
                return;
            }

            try
            {
                JObject rawData = JObject.Parse(ApiCallResult.Data);
                ResponseData = new LuisAppResponseRoot { query = (string)rawData["query"], prediction = new LuisAppPrediction() };
                //var predictionContent = (string)rawData["prediction"];
                ResponseData.prediction.topIntent = (string)rawData["prediction"]["topIntent"];

                //ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<LuisAppResponseRoot>(ApiCallResult.Data);
                //// If we only have errors, then the call was not successfull. However we can have a situation where multiple
                //// documents are submitted and some were processed ok but some were not. This indicates the action was successful
                //// but some some documents were not processed or valid.
                //if (ResponseData != null
                //        && ResponseData.errors != null
                //        && ResponseData.errors.Length > 0
                //        && (ResponseData.documents == null || ResponseData.documents.Length == 0))
                //{
                //    // If all that failed, we try just parsing into the error structure
                //    ActionSubmittedSuccessfully = false;
                //    return;
                //}
                //if (ResponseData == null || ResponseData.documents == null)
                //{
                //    var errors = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiErrorResponse>(ApiCallResult.Data);
                //    if (errors != null)
                //    {
                //        ResponseData = new SentimentResultResponseRoot { errors = new ApiErrorResponse[] { errors } };
                //    }
                //    ActionSubmittedSuccessfully = false;
                //    return;
                //}
                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                ResponseData = new LuisAppResponseRoot  { error = new BaseApiErrorResponse { message = $"Error parsing results: {ex.Message}" } };
                ActionSubmittedSuccessfully = false;
            }
        }
    }
}
