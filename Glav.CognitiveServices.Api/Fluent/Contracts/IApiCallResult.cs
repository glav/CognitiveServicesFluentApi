using Glav.CognitiveServices.Api.Communication;

namespace Glav.CognitiveServices.Api.Fluent.Contracts
{
    public interface IApiCallResult
    {
        bool ActionSubmittedSuccessfully { get; }
        ICommunicationResult ApiCallResult { get; }
    }
}
