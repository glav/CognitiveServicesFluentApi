using Glav.CognitiveServices.Api.Configuration;
using Glav.CognitiveServices.Api.Fluent.Contracts;
using Glav.CognitiveServices.Api.Fluent.Http;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.Api
{
    public sealed class AnalysisEngine
    {
        private readonly ApiAnalysisSettings _analysisSettings;

        public AnalysisEngine(ApiAnalysisSettings analysisSettings)
        {
            _analysisSettings = analysisSettings;
        }

        public ApiAnalysisSettings AnalysisSettings { get { return _analysisSettings; } }

        public async Task<ApiAnalysisResults> ExecuteAllAsync()
        {
            var apiResults = new ApiAnalysisResults();
            if (_analysisSettings.ActionsToPerform.ContainsKey(ApiActionType.TextAnalyticsSentiment))
            {
                var sentiments = _analysisSettings.ActionsToPerform[ApiActionType.TextAnalyticsSentiment] as TextAnalyticActionData;
                var payload = sentiments.ToString();

                var result = await new HttpFactory(_analysisSettings).CallService(ApiActionType.TextAnalyticsSentiment, payload);

                SentimentResult txtAnalyticResult;
                if (result.Successfull)
                {
                    txtAnalyticResult = new SentimentResult(result.Data);
                }
                else
                {
                    txtAnalyticResult = new SentimentResult();
                }
                var resultSet = new SentimentAnalysisSet(sentiments, txtAnalyticResult);
                apiResults.SetResult(resultSet);
            }

            if (_analysisSettings.ActionsToPerform.ContainsKey(ApiActionType.TextAnalyticsKeyphrases))
            {
                var phrases = _analysisSettings.ActionsToPerform[ApiActionType.TextAnalyticsKeyphrases] as TextAnalyticActionData;
                var payload = phrases.ToString();

                var result = await new HttpFactory(_analysisSettings).CallService(ApiActionType.TextAnalyticsKeyphrases, payload);

                KeyPhraseResult txtAnalyticResult;
                if (result.Successfull)
                {
                    txtAnalyticResult = new KeyPhraseResult(result.Data);
                    var resultSet = new KeyPhraseAnalysisSet(phrases, txtAnalyticResult);
                    apiResults.SetResult(resultSet);
                } else
                {
                    txtAnalyticResult = new KeyPhraseResult();
                }
            }

            return apiResults;

        }
    }
}
