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
            client.DefaultRequestHeaders.Add(HttpHeaders.SubscriptionKey, apiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HttpHeaders.MediaTypeApplicationJson));
            return client;
        }

        public async Task<ICommunicationResult> CallServiceAsync(ApiActionType apiActionType, byte[] payload, string urlQueryParameters = null)
        {
            var content = new ByteArrayContent(payload);
            content.Headers.ContentType = new MediaTypeHeaderValue(HttpHeaders.MediaTypeApplicationOctetStream);
            return await PostToServiceAsync(apiActionType, content, true, urlQueryParameters);
        }
        public async Task<ICommunicationResult> CallServiceAsync(ApiActionType apiActionType, string payload, string urlQueryParameters = null)
        {
            var content = new StringContent(payload,System.Text.Encoding.UTF8, HttpHeaders.MediaTypeApplicationJson);
            return await PostToServiceAsync(apiActionType, content, false,urlQueryParameters);
        }
        private async Task<ICommunicationResult> PostToServiceAsync(ApiActionType apiActionType, ByteArrayContent content, bool isBinaryPayload, string urlQueryParameters)
        {
            _configurationSettings.DiagnosticLogger.LogInfo($"Performing async service call for {apiActionType}", "HttpCommunicationEngine");

            var svcConfig = _configurationSettings.ServiceUris.GetServiceConfig(apiActionType);
            var uri = string.Format("{0}{1}{2}", _configurationSettings.BaseUrl, svcConfig.ServiceUri,
                            string.IsNullOrWhiteSpace(urlQueryParameters) ? string.Empty : $"?{urlQueryParameters}");

            try
            {
                using (var httpClient = HttpCommunicationEngine.CreateHttpClient(_configurationSettings.ApiKeys[svcConfig.ApiCategory]))
                {
                    var httpResult = await httpClient.PostAsync(uri, content).ConfigureAwait(continueOnCapturedContext: false);
                    _configurationSettings.DiagnosticLogger.LogInfo($"Async service call for {apiActionType} completed ok.", "HttpCommunicationEngine");
                    return await CommunicationResult.ParseResult(httpResult);
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
                    var httpResult = await httpClient.GetAsync(uri).ConfigureAwait(continueOnCapturedContext: false);
                    return await CommunicationResult.ParseResult(httpResult);
                }
            }
            catch (Exception ex)
            {
                return CommunicationResult.Fail(ex.Message);
            }
        }
    }
}
