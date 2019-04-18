using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System.Collections.Generic;
using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{
    public abstract class BaseResponseResult<TResponseData> 
        : IApiRequestResult<TResponseData> where TResponseData : IActionResponseRoot
    {
        public BaseResponseResult(ICommunicationResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
        }
        public TResponseData ResponseData { get; protected set; }

        public ICommunicationResult ApiCallResult { get; protected set; }
        public bool ActionSubmittedSuccessfully { get; protected set; }
    }

    public abstract class BaseResponseResultWithStrategy<TResponseRoot, TResponseItem>
       : IApiRequestResult<TResponseRoot>
        where TResponseRoot : IActionResponseRootWithError, new()
        where TResponseItem : class, new()
    {
        public BaseResponseResultWithStrategy(ICommunicationResult apiCallResult, IParsingStrategy<TResponseRoot, TResponseItem> parsingStrategy)
        {
            ApiCallResult = apiCallResult;
            ParsingStrategy = parsingStrategy;
        }
        public TResponseRoot ResponseData { get; protected set; }
        public TResponseItem ResponseItemData { get { return ParsingStrategy.ResponseItemData; } }

        public ICommunicationResult ApiCallResult { get; protected set; }
        public bool ActionSubmittedSuccessfully { get { return ParsingStrategy.ActionSubmittedSuccessfully; } }
        public IParsingStrategy<TResponseRoot, TResponseItem> ParsingStrategy { get; protected set; }

        public void ParseResponseData()
        {
            ParsingStrategy.ParseApiCall(ApiCallResult);
        }
    }

    public abstract class BaseResponseResulNoDatatWithStrategy<TResponseRoot>
      : IApiRequestResult<TResponseRoot>
       where TResponseRoot : class, IActionResponseRootWithError, new()
      // where TResponseItem : class, new()
    {
        public BaseResponseResulNoDatatWithStrategy(ICommunicationResult apiCallResult, IParsingStrategy<TResponseRoot, TResponseRoot> parsingStrategy)
        {
            ApiCallResult = apiCallResult;
            ParsingStrategy = parsingStrategy;
        }
        public TResponseRoot ResponseData { get { return ParsingStrategy.ResponseRootData; } }
        public TResponseRoot ResponseItemData { get { return ParsingStrategy.ResponseRootData; } }

        public ICommunicationResult ApiCallResult { get; protected set; }
        public bool ActionSubmittedSuccessfully { get { return ParsingStrategy.ActionSubmittedSuccessfully; } }
        public IParsingStrategy<TResponseRoot, TResponseRoot> ParsingStrategy { get; protected set; }

        public void ParseResponseData()
        {
            ParsingStrategy.ParseApiCall(ApiCallResult);

        }
    }
}
