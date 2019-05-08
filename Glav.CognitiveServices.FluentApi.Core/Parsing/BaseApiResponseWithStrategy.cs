using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{
    public abstract class BaseApiResponseWithStrategy<TResponseRoot,TResponse, TError>
      : IApiRequestResult<TResponseRoot>
        where TResponseRoot : IActionResponseRoot, new()
        where TError : class
    {
        public BaseApiResponseWithStrategy(ICommunicationResult apiCallResult, IParsingStrategy<TResponse, TError> parsingStrategy)
        {
            ApiCallResult = apiCallResult;
            ParsingStrategy = parsingStrategy;
        }
        public virtual TResponseRoot ResponseData { get; protected set; }

        public ICommunicationResult ApiCallResult { get; private set; }
        public virtual bool ActionSubmittedSuccessfully { get { return ParsingStrategy.ActionSubmittedSuccessfully; } }
        public IParsingStrategy<TResponse, TError> ParsingStrategy { get; protected set; }

        public void ParseResponseData()
        {
            ParsingStrategy.ParseApiCall(ApiCallResult);
        }
    }
}
