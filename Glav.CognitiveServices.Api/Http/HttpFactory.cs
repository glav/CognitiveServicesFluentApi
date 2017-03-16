using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.Api.Http
{
    internal class HttpFactory
    {
        private readonly ConfigurationSettings _configurationSettings;

        public HttpFactory(ConfigurationSettings configurationSettings)
        {
            _configurationSettings = configurationSettings;
        }
        public static HttpClient CreateHttpClient(string apiKey)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async Task<HttpResult> CallServiceAsync(ApiActionType apiActionType, string payload)
        {
            var uri = _configurationSettings.BaseUrl + ApiUrlExtensions.ApiServiceUrl(apiActionType);
            var content = new ByteArrayContent(System.Text.UTF8Encoding.UTF8.GetBytes(payload));
            try
            {
                using (var httpClient = HttpFactory.CreateHttpClient(_configurationSettings.ApiKey))
                {
                    var httpResult = await httpClient.PostAsync(uri, content);
                    return new HttpResult(httpResult);
                }
            }
            catch (Exception ex)
            {
                return HttpResult.Fail(ex.Message);
            }
        }
        public async Task<HttpResult> CallServiceAsync(string uri)
        {
            try
            {
                using (var httpClient = HttpFactory.CreateHttpClient(_configurationSettings.ApiKey))
                {
                    var httpResult = await httpClient.GetAsync(uri);
                    return new HttpResult(httpResult);
                }
            }
            catch (Exception ex)
            {
                return HttpResult.Fail(ex.Message);
            }
        }
    }
}
