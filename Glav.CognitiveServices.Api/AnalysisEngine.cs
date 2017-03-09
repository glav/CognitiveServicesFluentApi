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

            return apiResults;
        }

        private async Task AnalyseAllAsyncForAction(ApiAnalysisResults apiResults, ApiActionType apiAction)
        {
            if (_analysisSettings.ActionsToPerform.ContainsKey(apiAction))
            {
                var actions = _analysisSettings.ActionsToPerform[apiAction] as TextAnalyticActionData;
                var payload = actions.ToString();

                var result = await new HttpFactory(_analysisSettings).CallService(apiAction, payload);

                switch (apiAction)
                {
                    case ApiActionType.TextAnalyticsSentiment:
                        apiResults.SetResult(new SentimentAnalysisContext(actions, new SentimentResult(result.Data)));
                        break;
                    case ApiActionType.TextAnalyticsKeyphrases:
                        apiResults.SetResult(new KeyPhraseAnalysisContext(actions, new KeyPhraseResult(result.Data)));
                        break;
                    case ApiActionType.TextAnalyticsLanguages:
                        apiResults.SetResult(new LanguageAnalysisContext(actions, new LanguagesResult(result.Data)));
                        break;
                    default:
                        throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                }
            }
        }
    }
}
