using Glav.CognitiveServices.Api.Configuration;
using Glav.CognitiveServices.Api.Http;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class OperationStatusQueryEngine
    {
        private readonly TopicResult _topicResult;
        private readonly ConfigurationSettings _configurationSettings;

        public OperationStatusQueryEngine(ConfigurationSettings configurationSettings, TopicResult topicResult)
        {
            _configurationSettings = configurationSettings;
            _topicResult = topicResult;
        }

        public async Task<OperationStatusResult> CheckOperationStatus()
        {
            var factory = new HttpFactory(_configurationSettings);
            var serviceResult = await factory.CallServiceAsync(_topicResult.ApiCallResult.OperationLocationUri.AbsoluteUri);
            var result = new OperationStatusResult(serviceResult);
            return result;
        }
    }
}
