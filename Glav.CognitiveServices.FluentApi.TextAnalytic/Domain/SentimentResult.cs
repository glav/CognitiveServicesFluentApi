using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Parsing;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public sealed class SentimentResult : BaseApiResponse<SentimentResultResponseRoot>
    {
        public SentimentResult(ICommunicationResult apiCallResult) : base(apiCallResult)
        {
            AddResultToCollection();
        }

        private void AddResultToCollection()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new SentimentResultResponseRoot { errors = new ApiErrorResponse[] { new ApiErrorResponse { id = 1, message = StandardResponseCodes.NoDataReturnedMessage } } };
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<SentimentResultResponseRoot>(ApiCallResult.Data);
                // If we only have errors, then the call was not successfull. However we can have a situation where multiple
                // documents are submitted and some were processed ok but some were not. This indicates the action was successful
                // but some some documents were not processed or valid.
                if (ResponseData != null 
                        && ResponseData.errors != null 
                        && ResponseData.errors.Length > 0 
                        && (ResponseData.documents == null || ResponseData.documents.Length == 0))
                {
                    // If all that failed, we try just parsing into the error structure
                    ActionSubmittedSuccessfully = false;
                    return;
                }
                if (ResponseData == null || ResponseData.documents == null)
                {
                    var errors = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiErrorResponse>(ApiCallResult.Data);
                    if (errors != null)
                    {
                        ResponseData = new SentimentResultResponseRoot { errors = new ApiErrorResponse[] { errors } };
                    }
                    ActionSubmittedSuccessfully = false;
                    return;
                }
                ActionSubmittedSuccessfully = true;
            } catch (Exception ex)
            {
                ResponseData = new SentimentResultResponseRoot { errors = new ApiErrorResponse[] { new ApiErrorResponse { id = 1, message = $"Error parsing results: {ex.Message}" } } };
                ActionSubmittedSuccessfully = false;
            }
        }

    }


}
