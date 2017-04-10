using Glav.CognitiveServices.Api.Core.Communication;

namespace Glav.CognitiveServices.Api.Core.Contracts
{
    public interface IApiCallResult
    {
        bool ActionSubmittedSuccessfully { get; }
        ICommunicationResult ApiCallResult { get; }
    }
}
