using Glav.CognitiveServices.Api.Communication;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses;
using System;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class OperationStatusResult : BaseResponseResult<OperationStatusResultResponseRoot>
    {
        public OperationStatusResult()
        {
            OperationState = OperationStateType.NotStarted;
            Successfull = false;
        }
        public OperationStatusResult(CommunicationResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
            AddResultToCollection();
        }

        public OperationStateType OperationState { get; private set; }

        private void AddResultToCollection()
        {
            if (ApiCallResult == null)
            {
                ItemList.Add(new OperationStatusResultResponseRoot { status=OperationStatusResponseMessages.StatusFailed,  message = "No data returned." });
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
                if (ResponseData == null || string.IsNullOrWhiteSpace(ResponseData.status))
                {
                    Successfull = false;
                    OperationState = OperationStateType.BadRequest;
                    return;
                }

                ParseResult(ResponseData);
                Successfull = true;
            } catch (Exception ex)
            {
                OperationState = OperationStateType.Failed;
                ItemList.Add(new OperationStatusResultResponseRoot { status = OperationStatusResponseMessages.StatusFailed, message = $"Error parsing results: {ex.Message}" });
                Successfull = false;
            }
        }

        private void ParseResult(OperationStatusResultResponseRoot responseData)
        {
            if (responseData.status == OperationStatusResponseMessages.StatusBadRequest)
            {
                OperationState = OperationStateType.BadRequest;
                return;
            }
            OperationState = responseData.status.ToOperationStatus();
        }
    }


}
