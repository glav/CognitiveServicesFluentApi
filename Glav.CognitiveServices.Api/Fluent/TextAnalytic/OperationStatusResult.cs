using Glav.CognitiveServices.Api.Fluent.Contracts;
using Glav.CognitiveServices.Api.Fluent.Http;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class OperationStatusResult : BaseDataCollection<OperationStatusResultResponseRoot>, IApiAnalysisResult<OperationStatusResultResponseRoot>
    {
        public OperationStatusResult()
        {
            Successfull = false;
        }
        public OperationStatusResult(HttpResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
            AddResultToCollection();
        }

        private void AddResultToCollection()
        {
            if (ApiCallResult == null)
            {
                ItemList.Add(new OperationStatusResultResponseRoot { status="Failed",  message = "No data returned." });
                Successfull = false;
                return;
            }

            if (!ApiCallResult.Successfull)
            {
                Successfull = false;
                return;
            }

            try
            {
                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<OperationStatusResultResponseRoot>(ApiCallResult.Data);
                if (ResponseData == null || string.IsNullOrWhiteSpace(ResponseData.status) ||  ResponseData.status == "BadRequest")
                {
                    Successfull = false;
                    return;
                }
                Successfull = true;
            } catch (Exception ex)
            {
                ItemList.Add(new OperationStatusResultResponseRoot { status = "Failed", message = $"Error parsing results: {ex.Message}" });
                Successfull = false;
            }
        }

        // {"documents":[{"score":0.7988085,"id":"1"}],"errors":[]}
        public HttpResult ApiCallResult { get; private set; }
        public bool Successfull { get; private set; }
        public OperationStatusResultResponseRoot ResponseData { get; private set; }
    }


}
