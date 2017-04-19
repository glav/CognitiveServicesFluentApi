using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public sealed class TopicResult : BaseResponseResult<TopicResultResponseRoot>
    {
        public TopicResult(ICommunicationResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
            AddResultToCollection();
        }

        private void AddResultToCollection()
        {
            if (ApiCallResult == null)
            {
                ItemList.Add(new TopicResultResponseRoot { code = "BadRequest", message = "No data returned." });
                ActionSubmittedSuccessfully = false;
                return;
            }

            if (ApiCallResult.OperationLocationUri == null)
            {
                ActionSubmittedSuccessfully = false;
                ItemList.Add(new TopicResultResponseRoot { code = "BadRequest", message = "Bad request. Probably badly formatted request." });
                return;
            }

            try
            {
                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<TopicResultResponseRoot>(ApiCallResult.Data);
                // initial submission of topics returns no body of response just an 'accepted' and then it goes and processes it.
                if (ResponseData != null && !string.IsNullOrWhiteSpace(ResponseData.code)) 
                {
                    ActionSubmittedSuccessfully = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                ItemList.Add(new TopicResultResponseRoot { code = "BadRequest", message = $"Error parsing result: [{ex.Message}]" });
                ActionSubmittedSuccessfully = false;
            }

            ResponseData = new TopicResultResponseRoot { code = "Submitted" };
            ActionSubmittedSuccessfully = true;
        }

    }


}
