﻿using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public sealed class TextAnalyticAnalysisEngine : IAnalysisEngine<TextAnalyticAnalysisResults>
    {
        public TextAnalyticAnalysisEngine(AnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }

        public AnalysisSettings AnalysisSettings { get; private set; }

        public async Task<TextAnalyticAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new TextAnalyticAnalysisResults(AnalysisSettings);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.TextAnalyticsSentiment);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.TextAnalyticsKeyphrases);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.TextAnalyticsLanguages);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.TextAnalyticsTopics);

            return apiResults;
        }


        private async Task AnalyseAllAsyncForAction(TextAnalyticAnalysisResults apiResults, ApiActionType apiAction)
        {
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction))
            {
                string payload = null;
                var actions = AnalysisSettings.ActionsToPerform[apiAction];
                if (apiAction == ApiActionType.TextAnalyticsTopics)
                {
                    payload = (actions as TextAnalyticTopicActionData).ToString();
                } else
                {
                    payload = (actions as TextAnalyticActionData).ToString();
                }

                var result = await AnalysisSettings.CommunicationEngine.CallServiceAsync(apiAction, payload);

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
