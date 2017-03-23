using Glav.CognitiveServices.Api.Communication;

namespace Glav.CognitiveServices.Api.Fluent.Contracts
{
    public interface IApiCallResult
    {
        bool Successfull { get; }
        CommunicationResult ApiCallResult { get; }
    }
}
