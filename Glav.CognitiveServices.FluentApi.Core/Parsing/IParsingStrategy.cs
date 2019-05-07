using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{

    public interface IParsingStrategy<TResponse,TError>
        where TError : class
    {
        bool ActionSubmittedSuccessfully { get; }
        TResponse ResponseData { get; }
        TError ResponseError { get; }
        void ParseApiCall(ICommunicationResult apiCallResult);
    }

    public abstract class BaseParsingStrategy<TResponse,TError> : IParsingStrategy<TResponse, TError>
        where TError : class
    {
        public bool ActionSubmittedSuccessfully { get; protected set; }

        public TResponse ResponseData { get; protected set; }

        public TError ResponseError { get; protected set; }

        public abstract void ParseApiCall(ICommunicationResult apiCallResult);
        protected void SetStandardError(string code, string message)
        {
            var errResponse = ResponseData as IActionResponseRootWithError;
            if (errResponse != null)
            {
                errResponse.error = new BaseApiErrorResponse { code = code, message = message };
            }
        }

    }

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
