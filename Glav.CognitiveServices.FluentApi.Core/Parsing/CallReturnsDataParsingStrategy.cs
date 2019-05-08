using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{
    public class CallReturnsDataParsingStrategy<TResponse, TError> : BaseParsingStrategy<TResponse, TError>
        where TError : class
    {
        public override void ParseApiCall(ICommunicationResult apiCallResult)
        {
            if (apiCallResult == null)
            {
                SetStandardError(StandardResponseCodes.NoDataReturned, StandardResponseCodes.NoDataReturnedMessage);
                ActionSubmittedSuccessfully = false;
                return;
            }

            try
            {
                ActionSubmittedSuccessfully = false;
                if ((int)apiCallResult.StatusCode == 0)
                {
                    SetStandardError(StandardResponseCodes.ServerError, apiCallResult.ErrorMessage);
                    return;
                }
                if ((int)apiCallResult.StatusCode >= 400)
                {
                    ResponseError = Newtonsoft.Json.JsonConvert.DeserializeObject<TError>(apiCallResult.Data);
                    return;
                }

                if (apiCallResult.StatusCode == System.Net.HttpStatusCode.Accepted && apiCallResult.OperationLocationUri != null)
                {
                    ActionSubmittedSuccessfully = true;
                    return;
                }

                if (apiCallResult.StatusCode == System.Net.HttpStatusCode.Accepted && apiCallResult.OperationLocationUri == null)
                {
                    SetStandardError(StandardResponseCodes.OperationAcceptedButNoOperationLocationUri, StandardResponseCodes.OperationAcceptedButNoOperationLocationUriMessage);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(apiCallResult.Data))
                {
                    ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(apiCallResult.Data);
                    if (ResponseData == null)
                    {
                        ResponseError = Newtonsoft.Json.JsonConvert.DeserializeObject<TError>(apiCallResult.Data);
                        return;
                    }
                }
                ActionSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                SetStandardError(StandardResponseCodes.ServerError, $"Error parsing results: {ex.Message}");
                ActionSubmittedSuccessfully = false;
            }
        }
    }
}
