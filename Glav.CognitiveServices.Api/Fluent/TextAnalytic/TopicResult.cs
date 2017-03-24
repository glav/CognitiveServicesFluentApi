using Glav.CognitiveServices.Api.Communication;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses;
using System;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
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
                Successfull = false;
                return;
            }

            if (ApiCallResult.OperationLocationUri == null)
            {
                Successfull = false;
                ItemList.Add(new TopicResultResponseRoot { code = "BadRequest", message = "Bad request. Probably badly formatted request." });
                return;
            }

            try
            {
                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<TopicResultResponseRoot>(ApiCallResult.Data);
                // initial submission of topics returns no body of response just an 'accepted' and then it goes and processes it.
                if (ResponseData != null && !string.IsNullOrWhiteSpace(ResponseData.code)) 
                {
                    Successfull = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                ItemList.Add(new TopicResultResponseRoot { code = "BadRequest", message = $"Error parsing result: [{ex.Message}]" });
                Successfull = false;
            }

            ResponseData = new TopicResultResponseRoot { code = "Submitted" };
            Successfull = true;
        }

    }


}
