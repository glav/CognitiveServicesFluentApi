using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IApiCallResult
    {
        bool ActionSubmittedSuccessfully { get; }
        ICommunicationResult ApiCallResult { get; }
    }
}
