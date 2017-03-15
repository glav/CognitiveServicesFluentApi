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

        public async Task<ApiAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new ApiAnalysisResults();
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.TextAnalyticsSentiment);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.TextAnalyticsKeyphrases);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.TextAnalyticsLanguages);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.TextAnalyticsTopics);

            return apiResults;
        }

        private async Task AnalyseAllAsyncForAction(ApiAnalysisResults apiResults, ApiActionType apiAction)
        {
            if (_analysisSettings.ActionsToPerform.ContainsKey(apiAction))
            {
                string payload = null;
                var actions = _analysisSettings.ActionsToPerform[apiAction];
                if (apiAction == ApiActionType.TextAnalyticsTopics)
                {
                    payload = (actions as TextAnalyticTopicActionData).ToString();
                } else
                {
                    payload = (actions as TextAnalyticActionData).ToString();
                }

                var result = await new HttpFactory(_analysisSettings.ConfigurationSettings).CallServiceAsync(apiAction, payload);

                switch (apiAction)
                {
                    case ApiActionType.TextAnalyticsSentiment:
                        apiResults.SetResult(new SentimentAnalysisContext((actions as TextAnalyticActionData), new SentimentResult(result)));
                        break;
                    case ApiActionType.TextAnalyticsKeyphrases:
                        apiResults.SetResult(new KeyPhraseAnalysisContext((actions as TextAnalyticActionData), new KeyPhraseResult(result)));
                        break;
                    case ApiActionType.TextAnalyticsLanguages:
                        apiResults.SetResult(new LanguageAnalysisContext((actions as TextAnalyticActionData), new LanguagesResult(result)));
                        break;
                    case ApiActionType.TextAnalyticsTopics:
                        apiResults.SetResult(new TopicAnalysisContext((actions as TextAnalyticTopicActionData), new TopicResult(result)));
                        break;
                    default:
                        throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                }
            }
        }
    }
}
