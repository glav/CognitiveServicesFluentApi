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
        public TextAnalyticAnalysisEngine(CoreAnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }

        public CoreAnalysisSettings AnalysisSettings { get; private set; }

        public async Task<TextAnalyticAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new TextAnalyticAnalysisResults(AnalysisSettings);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.TextAnalyticsSentiment);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.TextAnalyticsKeyphrases);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.TextAnalyticsLanguages);

            return apiResults;
        }


        private async Task AnalyseAllAsyncForAction(TextAnalyticAnalysisResults apiResults, ApiActionType apiAction)
        {
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction))
            {
                var actions = AnalysisSettings.ActionsToPerform[apiAction];
                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Serialising payload for {apiAction.ToString()}", "AnalyseAll");
                var payload = (actions as TextAnalyticActionData).ToString();

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Calling service for {apiAction.ToString()}", "AnalyseAll");

                var result = await AnalysisSettings.CommunicationEngine.CallServiceAsync(apiAction, payload);

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Processing results of service call for {apiAction.ToString()}", "AnalyseAll");

                switch (apiAction)
                {
                    case ApiActionType.TextAnalyticsSentiment:
                        apiResults.SetResult(new SentimentAnalysisContext((actions as TextAnalyticActionData), new SentimentResult(result), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                        break;
                    case ApiActionType.TextAnalyticsKeyphrases:
                        apiResults.SetResult(new KeyPhraseAnalysisContext((actions as TextAnalyticActionData), new KeyPhraseResult(result), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                        break;
                    case ApiActionType.TextAnalyticsLanguages:
                        apiResults.SetResult(new LanguageAnalysisContext((actions as TextAnalyticActionData), new LanguagesResult(result), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                        break;
                    default:
                        throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                }
            }
        }
    }
}
