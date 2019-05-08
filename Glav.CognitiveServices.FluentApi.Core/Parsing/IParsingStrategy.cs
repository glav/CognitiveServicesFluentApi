using Glav.CognitiveServices.FluentApi.Core.Communication;
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
}
