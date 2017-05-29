using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Core.Communication
{
    internal class HttpCommunicationEngine : ICommunicationEngine
    {
        private readonly ConfigurationSettings _configurationSettings;

        public HttpCommunicationEngine(ConfigurationSettings configurationSettings)
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
            _configurationSettings.DiagnosticLogger.LogInfo($"Performing async service call for {apiActionType}", "HttpCommunicationEngine");

            var svcConfig = _configurationSettings.ServiceUrls.GetServiceConfig(apiActionType);
            var uri = string.Format("{0}{1}", _configurationSettings.BaseUrl,svcConfig.ServiceUri);
            var content = new ByteArrayContent(System.Text.UTF8Encoding.UTF8.GetBytes(payload));
            try
            {
                using (var httpClient = HttpCommunicationEngine.CreateHttpClient(_configurationSettings.ApiKeys[svcConfig.ApiCategory]))
                {
                    var httpResult = await httpClient.PostAsync(uri, content);
                    _configurationSettings.DiagnosticLogger.LogInfo($"Async service call for {apiActionType} completed ok.", "HttpCommunicationEngine");
                    return new CommunicationResult(httpResult);
                }
            }
            catch (Exception ex)
            {
                _configurationSettings.DiagnosticLogger.LogError(ex, "HttpCommunicationEngine");
                return CommunicationResult.Fail(ex.Message);
            }
        }
        public async Task<ICommunicationResult> CallServiceAsync(string uri, ApiActionCategory apiCategory)
        {
            try
            {
                using (var httpClient = HttpCommunicationEngine.CreateHttpClient(_configurationSettings.ApiKeys[apiCategory]))
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
