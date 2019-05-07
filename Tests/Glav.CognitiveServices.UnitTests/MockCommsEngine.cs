using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.UnitTests
{
    public class MockCommsEngine : ICommunicationEngine
    {
        private ICommunicationResult _mockResult;
        private bool _shouldBlowUp;
        public MockCommsEngine(ICommunicationResult mockResult, bool shouldBlowUp = false)
        {
            _mockResult = mockResult;
            _shouldBlowUp = shouldBlowUp;
        }

        public Task<ICommunicationResult> CallBatchServiceAsync(ApiActionDataCollection actionItemCollection)
        {
            if (_shouldBlowUp)
            {
                return Task.FromResult<ICommunicationResult>(CommunicationResult.Fail("Boom!"));
            }
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }

        public Task<ICommunicationResult> CallServiceAsync(IActionDataItem actionItem)
        {
            if (_shouldBlowUp)
            {
                return Task.FromResult<ICommunicationResult>(CommunicationResult.Fail("Boom!"));
            }
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }

        public Task<ICommunicationResult> ServiceGetAsync(string uri, string category)
        {
            if (_shouldBlowUp)
            {
                return Task.FromResult<ICommunicationResult>(CommunicationResult.Fail("Boom!"));
            }
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }
    }
}
