using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.Core.Parsing
{
    public class BaseApiResponseReturnsData<TResponseRoot,TResponse, TError>
       : BaseApiResponseWithStrategy<TResponseRoot,TResponse, TError>
        where TResponseRoot : IActionResponseRoot, new()
    {
        public BaseApiResponseReturnsData(ICommunicationResult apiCallResult) : base(apiCallResult, new CallReturnsDataParsingStrategy<TResponse, TError>())
        {
        }
    }
}
