using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public sealed class AnalysisFactory
    {
        public AnalysisFactory(ApiAnalysisSettings apiAnalysisSettings)
        {
            AnalysisSettings = apiAnalysisSettings;
        }

        public ApiAnalysisSettings AnalysisSettings { get; private set; }

        public HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AnalysisSettings.ConfigurationSettings.ApiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public ApiAnalysisResults Analyse()
        {
            var apiResults = new ApiAnalysisResults();
            var sentiments = AnalysisSettings.ActionsToPerform.Where(a => a.ActionType == Configuration.ApiActionType.TextAnalyticsSentiment).ToList();
            if (sentiments.Count > 0)
            {
                var client = CreateHttpClient();
                var payload = "{ \"documents\":[ {\"language\":\"en\", \"id\":\"1\", \"text\":\"" + sentiments[0].ActionData + "\" } ] }";
                var content = new ByteArrayContent(System.Text.UTF8Encoding.UTF8.GetBytes(payload));
                var url = AnalysisSettings.ConfigurationSettings.BaseUrl + ApiUrlExtensions.ApiServiceUrl(ApiActionType.TextAnalyticsSentiment);
                var result = client.PostAsync(url,content).Result;
                apiResults.SentimentResults = result.Content.ReadAsStringAsync().Result;
            }

            return apiResults;
        }

    }
}
