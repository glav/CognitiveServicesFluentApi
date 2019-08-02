using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{
    public abstract class BaseParsingStrategy<TResponse,TError> : IParsingStrategy<TResponse, TError> 
        where TResponse : class
        where TError : class, new()
    {
        public bool ActionSubmittedSuccessfully { get; protected set; }

        public TResponse ResponseData { get; protected set; }

        public TError ResponseError { get; protected set; }

        public abstract void ParseApiCall(ICommunicationResult apiCallResult);
        protected void SetStandardError(string code, string message)
        {
            ResponseError = new TError();
            var errResponseData = ResponseData as IActionResponseRootWithError;
            if (errResponseData != null)
            {
                errResponseData.error = new BaseApiErrorResponse { code = code, message = message };
            }

            var errResponseError = ResponseError as IActionResponseRootWithError;
            if (errResponseError != null)
            {
                errResponseError.error = new BaseApiErrorResponse { code = code, message = message };
                return;
            }

            var baseError = ResponseError as IBaseApiErrorResponse;
            if (baseError != null)
            {
                baseError.code = code;
                baseError.message = message;
            }
        }

    }
}
