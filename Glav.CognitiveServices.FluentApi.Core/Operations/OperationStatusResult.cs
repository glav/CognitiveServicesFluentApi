using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;

namespace Glav.CognitiveServices.FluentApi.Core.Operations
{
    public sealed class OperationStatusResult : BaseResponseResult<OperationStatusResultResponseRoot>
    {
        public OperationStatusResult(ICommunicationResult apiCallResult)
        {
            OperationState = OperationStateType.NotStarted;
            ApiCallResult = apiCallResult;
            AddResultToCollection();
        }

        public OperationStateType OperationState { get; private set; }

        private void AddResultToCollection()
        {
            if (ApiCallResult == null)
            {
                ResponseData = new OperationStatusResultResponseRoot { status=OperationStatusResponseMessages.StatusFailed,  message = "No data returned." };
                ActionSubmittedSuccessfully = false;
                return;
            }

            if (!ApiCallResult.Successfull)
            {
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<OperationStatusResultResponseRoot>(ApiCallResult.Data);
                if (ResponseData == null || string.IsNullOrWhiteSpace(ResponseData.status))
                {
                    ActionSubmittedSuccessfully = false;
                    OperationState = OperationStateType.BadRequest;
                    return;
                }

                ParseResult(ResponseData);
                ActionSubmittedSuccessfully = true;
            } catch (Exception ex)
            {
                OperationState = OperationStateType.Failed;
                ResponseData = new OperationStatusResultResponseRoot { status = OperationStatusResponseMessages.StatusFailed, message = $"Error parsing results: {ex.Message}" };
                ActionSubmittedSuccessfully = false;
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

        public static OperationStatusResult CreateTimeoutOperation(ICommunicationResult apiCallResult)
        {
            var result = new OperationStatusResult(apiCallResult);
            result.OperationState = OperationStateType.TimedOut;
            return result;
        }
        public static OperationStatusResult CreateCancelledOperation(ICommunicationResult apiCallResult)
        {
            var result = new OperationStatusResult(apiCallResult);
            result.OperationState = OperationStateType.Cancelled;
            return result;
        }
    }


}
