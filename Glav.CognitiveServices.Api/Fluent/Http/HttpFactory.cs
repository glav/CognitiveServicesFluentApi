using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.Api.Fluent.Http
{
    internal class HttpFactory
    {
        private readonly ApiAnalysisSettings _analysisSettings;

        public HttpFactory(ApiAnalysisSettings analysisSettings)
        {
            _analysisSettings = analysisSettings;
        }
        public static HttpClient CreateHttpClient(string apiKey)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async Task<HttpResult> CallService(ApiActionType apiActionType, string payload)
        {
            var content = new ByteArrayContent(System.Text.UTF8Encoding.UTF8.GetBytes(payload));
            var url = _analysisSettings.ConfigurationSettings.BaseUrl + ApiUrlExtensions.ApiServiceUrl(apiActionType);
            try
            {
                using (var httpClient = HttpFactory.CreateHttpClient(_analysisSettings.ConfigurationSettings.ApiKey))
                {
                    var httpResult = await httpClient.PostAsync(url, content);
                    return HttpResult.Success(await httpResult.Content.ReadAsStringAsync());
                }
            } catch (Exception ex)
            {
                return HttpResult.Fail(ex.Message);
            }

        }
    }
}
