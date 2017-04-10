using Glav.CognitiveServices.Api.Core.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.Api.Core.Communication
{
    internal class CommunicationEngine : ICommunicationEngine
    {
        private readonly ConfigurationSettings _configurationSettings;

        public CommunicationEngine(ConfigurationSettings configurationSettings)
        {
            _configurationSettings = configurationSettings;
        }
        private static HttpClient CreateHttpClient(string apiKey)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async Task<ICommunicationResult> CallServiceAsync(ApiActionType apiActionType, string payload)
        {
            var uri = _configurationSettings.BaseUrl + ApiUrlExtensions.ApiServiceUrl(apiActionType);
            var content = new ByteArrayContent(System.Text.UTF8Encoding.UTF8.GetBytes(payload));
            try
            {
                using (var httpClient = CommunicationEngine.CreateHttpClient(_configurationSettings.ApiKey))
                {
                    var httpResult = await httpClient.PostAsync(uri, content);
                    return new CommunicationResult(httpResult);
                }
            }
            catch (Exception ex)
            {
                return CommunicationResult.Fail(ex.Message);
            }
        }
        public async Task<ICommunicationResult> CallServiceAsync(string uri)
        {
            try
            {
                using (var httpClient = CommunicationEngine.CreateHttpClient(_configurationSettings.ApiKey))
                {
                    var httpResult = await httpClient.GetAsync(uri);
                    return new CommunicationResult(httpResult);
                }
            }
            catch (Exception ex)
            {
                return CommunicationResult.Fail(ex.Message);
            }
        }
    }
}
