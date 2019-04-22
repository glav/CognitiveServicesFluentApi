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

    public abstract class BaseApiResponseWithStrategy<TResponseRoot, TResponseItem>
      : IApiRequestResult<TResponseRoot>
       where TResponseRoot : IActionResponseRootWithError, new()
       where TResponseItem : class
    {
        public BaseApiResponseWithStrategy(ICommunicationResult apiCallResult, IParsingStrategy<TResponseRoot, TResponseItem> parsingStrategy)
        {
            ApiCallResult = apiCallResult;
            ParsingStrategy = parsingStrategy;
        }
        public TResponseRoot ResponseData { get; protected set; }

        public ICommunicationResult ApiCallResult { get; protected set; }
        public bool ActionSubmittedSuccessfully { get { return ParsingStrategy.ActionSubmittedSuccessfully; } }
        public IParsingStrategy<TResponseRoot, TResponseItem> ParsingStrategy { get; protected set; }

        public void ParseResponseData()
        {
            ParsingStrategy.ParseApiCall(ApiCallResult);
        }
    }

    public abstract class BaseApiResponseReturnsData<TResponseRoot, TResponseItem>
       : BaseApiResponseWithStrategy<TResponseRoot, TResponseItem>
        where TResponseRoot : IActionResponseRootWithError, new()
        where TResponseItem : class
    {
        public BaseApiResponseReturnsData(ICommunicationResult apiCallResult) : base(apiCallResult, new CallReturnsDataParsingStrategy<TResponseRoot,TResponseItem>())
        {
        }
    }

    public abstract class BaseApiResponseReturnsNoData<TResponseRoot>
      : BaseApiResponseWithStrategy<TResponseRoot, TResponseRoot>
       where TResponseRoot : class, IActionResponseRootWithError, new()
    {
        public BaseApiResponseReturnsNoData(ICommunicationResult apiCallResult) : base(apiCallResult,new CallReturnsNoDataParsingStrategy<TResponseRoot>())
        {
        }
    }
}
