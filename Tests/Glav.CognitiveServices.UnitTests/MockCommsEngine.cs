using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Communication;
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

        public Task<ICommunicationResult> CallServiceAsync(ApiActionType apiActionType, string payload)
        {
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }

        public Task<ICommunicationResult> CallServiceAsync(string uri)
        {
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }
    }
}
