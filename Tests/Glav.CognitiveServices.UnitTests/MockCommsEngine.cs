using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.UnitTests
{
    public class MockCommsEngine : ICommunicationEngine
    {
        private ICommunicationResult _mockResult;
        public MockCommsEngine(ICommunicationResult mockResult)
        {
            _mockResult = mockResult;
        }

        public Task<ICommunicationResult> CallServiceAsync(ApiActionType apiActionType, string payload, string urlQueryParameters, bool isBinaryPayload)
        {
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }

        public Task<ICommunicationResult> CallServiceAsync(string uri, ApiActionCategory apiCategory, bool isBinaryPayload)
        {
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }
    }
}
