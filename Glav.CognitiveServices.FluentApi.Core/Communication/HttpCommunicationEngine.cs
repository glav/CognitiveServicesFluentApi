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

        public async Task<ICommunicationResult> ServicePostAsync(ApiActionDefinition apiActionType, byte[] payload, string urlQueryParameters = null)
        {
            var content = new ByteArrayContent(payload);
            content.Headers.ContentType = new MediaTypeHeaderValue(HttpHeaders.MediaTypeApplicationOctetStream);
            return await CallServiceInternalAsync(apiActionType, HttpMethod.Post, content, urlQueryParameters);
        }
        public async Task<ICommunicationResult> ServicePostAsync(ApiActionDefinition apiActionType, string payload, string urlQueryParameters = null)
        {
            var content = new StringContent(payload, System.Text.Encoding.UTF8, HttpHeaders.MediaTypeApplicationJson);
            return await CallServiceInternalAsync(apiActionType, HttpMethod.Post, content, urlQueryParameters);
        }
        public async Task<ICommunicationResult> ServicePutAsync(ApiActionDefinition apiActionType, byte[] payload, string urlQueryParameters = null)
        {
            var content = new ByteArrayContent(payload);
            content.Headers.ContentType = new MediaTypeHeaderValue(HttpHeaders.MediaTypeApplicationOctetStream);
            return await CallServiceInternalAsync(apiActionType, HttpMethod.Put, content, urlQueryParameters);
        }
        public async Task<ICommunicationResult> ServicePutAsync(ApiActionDefinition apiActionType, string payload, string urlQueryParameters = null)
        {
            var content = new StringContent(payload, System.Text.Encoding.UTF8, HttpHeaders.MediaTypeApplicationJson);
            return await CallServiceInternalAsync(apiActionType, HttpMethod.Put, content, urlQueryParameters);
        }
        private async Task<ICommunicationResult> CallServiceInternalAsync(ApiActionDefinition apiActionType, HttpMethod httpAction, ByteArrayContent content, string urlQueryParameters)
        {
            _configurationSettings.DiagnosticLogger.LogInfo($"Performing async service call for {apiActionType}", "HttpCommunicationEngine");

            var svcConfig = _configurationSettings.ServiceUris.GetServiceConfig(apiActionType);
            var uri = string.Format("{0}{1}{2}", _configurationSettings.BaseUrl, svcConfig.ServiceUri,
                            string.IsNullOrWhiteSpace(urlQueryParameters) ? string.Empty : $"?{urlQueryParameters}");

            try
            {
                using (var httpClient = HttpCommunicationEngine.CreateHttpClient(_configurationSettings.ApiKeys[svcConfig.ApiAction.Category]))
                {
                    HttpResponseMessage httpResult;
                    if (httpAction == HttpMethod.Put)
                    {
                        httpResult = await httpClient.PutAsync(uri, content).ConfigureAwait(continueOnCapturedContext: false);

                    }
                    else
                    {
                        httpResult = await httpClient.PostAsync(uri, content).ConfigureAwait(continueOnCapturedContext: false);

                    }
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
        public async Task<ICommunicationResult> ServiceGetAsync(string uri, string category)
        {
            try
            {
                using (var httpClient = HttpCommunicationEngine.CreateHttpClient(_configurationSettings.ApiKeys[category]))
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

        public Task<ICommunicationResult> CallServiceAsync(ApiActionDefinition apiActionType, string payload, string urlQueryParameters = null)
        {
            throw new NotImplementedException();
        }

        public async Task<ICommunicationResult> CallServiceAsync(ApiActionDefinition apiActionType, byte[] payload, string urlQueryParameters = null)
        {
            var content = new ByteArrayContent(payload);
            content.Headers.ContentType = new MediaTypeHeaderValue(HttpHeaders.MediaTypeApplicationOctetStream);

            if (apiActionType.Method == HttpMethod.Post)
            {
                return await CallServiceInternalAsync(apiActionType,apiActionType.Method, content, urlQueryParameters);
            }
            if (apiActionType.Method == HttpMethod.Put)
            {
                return await CallServiceInternalAsync(apiActionType, apiActionType.Method, content, urlQueryParameters);
            }
            throw new NotImplementedException();
        }
    }
}
