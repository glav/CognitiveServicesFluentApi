using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
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

        public Task<ICommunicationResult> CallBatchServiceAsync(ApiActionDataCollection actionItemCollection)
        {
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }

        public Task<ICommunicationResult> CallServiceAsync(IActionDataItem actionItem)
        {
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }

        public Task<ICommunicationResult> ServiceGetAsync(string uri, string category)
        {
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }
    }
}
