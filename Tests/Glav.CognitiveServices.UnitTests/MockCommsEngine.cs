﻿using Glav.CognitiveServices.FluentApi.Core.Communication;
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

        public Task<ICommunicationResult> CallServiceAsync(ApiActionType apiActionType, string payload, string urlQueryParameters = null)
        {
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }

        public Task<ICommunicationResult> CallServiceAsync(ApiActionType apiActionType, byte[] payload, string urlQueryParameters = null)
        {
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }

        public Task<ICommunicationResult> CallServiceAsync(string uri, ApiActionCategory apiCategory)
        {
            return Task.FromResult<ICommunicationResult>(_mockResult);
        }
    }
}
