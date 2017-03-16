using Glav.CognitiveServices.Api.Http;

namespace Glav.CognitiveServices.Api.Fluent.Contracts
{
    public interface IApiCallResult
    {
        bool Successfull { get; }
        HttpResult ApiCallResult { get; }
    }
}
