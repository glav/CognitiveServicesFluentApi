using Glav.CognitiveServices.Api.Fluent.Contracts;
using Glav.CognitiveServices.Api.Fluent.Http;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class TopicResult : BaseDataCollection<TopicResultResponseRoot>, IApiAnalysisResult<TopicResultResponseRoot>
    {
        public TopicResult()
        {
            Successfull = false;
        }
        public TopicResult(HttpResult apiCallResult)
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
                if (ResponseData == null || !string.IsNullOrWhiteSpace(ResponseData.code))
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

        public HttpResult ApiCallResult { get; private set; }
        public bool Successfull { get; private set; }
        public TopicResultResponseRoot ResponseData { get; private set; }
    }


}
