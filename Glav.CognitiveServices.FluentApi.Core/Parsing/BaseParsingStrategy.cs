using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{
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
}
