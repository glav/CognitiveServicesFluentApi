using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System.Collections.Generic;
using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{
    public abstract class BaseApiResponse<TResponseData> 
        : IApiRequestResult<TResponseData> where TResponseData : IActionResponseRoot
    {
        public BaseApiResponse(ICommunicationResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
        }
        public TResponseData ResponseData { get; protected set; }

        public ICommunicationResult ApiCallResult { get; protected set; }
        public bool ActionSubmittedSuccessfully { get; protected set; }
    }

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

    public abstract class BaseApiResponseReturnsData<TResponseRoot,TResponse, TError>
       : BaseApiResponseWithStrategy<TResponseRoot,TResponse, TError>
        where TResponseRoot : IActionResponseRoot, new()
        where TError : class
    {
        public BaseApiResponseReturnsData(ICommunicationResult apiCallResult) : base(apiCallResult, new CallReturnsDataParsingStrategy<TResponse, TError>())
        {
        }
    }

    public abstract class BaseApiResponseWithStandardErrorReturnsData<TResponseRoot,TResponse>
       : BaseApiResponseWithStrategy<TResponseRoot,TResponse, BaseApiErrorResponse>
        where TResponseRoot : IActionResponseRoot, new()
    {
        public BaseApiResponseWithStandardErrorReturnsData(ICommunicationResult apiCallResult) : base(apiCallResult, new CallReturnsDataParsingStrategy<TResponse, BaseApiErrorResponse>())
        {
        }
    }
}
