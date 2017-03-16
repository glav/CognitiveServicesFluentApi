using Glav.CognitiveServices.Api.Http;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses;
using System;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class OperationStatusResult : BaseResponseResult<OperationStatusResultResponseRoot>
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

    }


}
