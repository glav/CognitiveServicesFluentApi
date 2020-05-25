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
            if (ResponseData is IActionResponseRootWithError errResponseData)
            {
                errResponseData.error = new BaseApiErrorResponse { code = code, message = message };
            }

            if (ResponseError is IActionResponseRootWithError errResponseError)
            {
                errResponseError.error = new BaseApiErrorResponse { code = code, message = message };
                return;
            }

            if (ResponseError is IBaseApiErrorResponse baseError)
            {
                baseError.code = code;
                baseError.message = message;
            }
        }

    }
}
