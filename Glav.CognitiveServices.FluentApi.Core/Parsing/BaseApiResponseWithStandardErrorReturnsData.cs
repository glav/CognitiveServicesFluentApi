using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{
    public abstract class BaseApiResponseWithStandardErrorReturnsData<TResponseRoot,TResponse>
       : BaseApiResponseWithStrategy<TResponseRoot,TResponse, BaseApiErrorResponse>
        where TResponseRoot : IActionResponseRoot, new()
    {
        public BaseApiResponseWithStandardErrorReturnsData(ICommunicationResult apiCallResult) : base(apiCallResult, new CallReturnsDataParsingStrategy<TResponse, BaseApiErrorResponse>())
        {
        }
    }
}
