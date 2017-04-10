﻿using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System.Linq;
using Glav.CognitiveServices.Api.Fluent.Contracts;
using System.Threading.Tasks;
using Glav.CognitiveServices.Api.Core;
using Glav.CognitiveServices.Api.Core.Configuration;

namespace Glav.CognitiveServices.Api.Fluent
{
    public static class TextAnalyticFluentApiExtensions
    {
        public static async Task<AnalysisResults> AnalyseAllAsync(this AnalysisSettings apiAnalysisSettings)
        {
            var engine = new TextAnalyticAnalysisEngine(apiAnalysisSettings);
            return await engine.AnalyseAllAsync();
        }

        public static AnalysisSettings WithSentimentAnalysis(this AnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsSentiment);
        }

        public static AnalysisSettings WithKeyPhraseAnalysis(this AnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsKeyphrases);
        }

        public static AnalysisSettings WithKeyLanguageAnalysis(this AnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsLanguages);
        }

        public static AnalysisSettings WithKeyTopicAnalysis(this AnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsTopics);
        }
        public static AnalysisSettings WithKeyTopicAnalysisSplittingDataIntoSentences(this AnalysisSettings apiAnalysis, string textToAnalyse)
        {
            var sentences = textToAnalyse.SplitTextIntoSentences();
            foreach(var sentence in sentences)
            {
                apiAnalysis.AddTextForAnalysis(sentence, ApiActionType.TextAnalyticsTopics);
            }
            return apiAnalysis;
            
        }

        public static AnalysisSettings WithKeyTopicAnalysis(this AnalysisSettings apiAnalysis, string textToAnalyse, IEnumerable<string> topicsToExclude)
        {
            var actionData = GetOrCreateActionInstance<TextAnalyticTopicActionData>(apiAnalysis, ApiActionType.TextAnalyticsTopics);
            actionData.Add(textToAnalyse);
            return apiAnalysis;//.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsTopics);
        }

        private static T GetOrCreateActionInstance<T>(AnalysisSettings apiAnalysis, ApiActionType actionType) where T : class, IApiActionData, new()
        {
            if (apiAnalysis.ActionsToPerform.ContainsKey(actionType))
            {
                return apiAnalysis.ActionsToPerform[actionType] as T;
            }

            var data = new T();
            apiAnalysis.ActionsToPerform.Add(actionType, data);
            return data;

        }
        private static AnalysisSettings AddTextForAnalysis(this AnalysisSettings apiAnalysis, string textToAnalyse, ApiActionType actionType)
        {
            if (actionType == ApiActionType.TextAnalyticsTopics)
            {
                var topicActionData = GetOrCreateActionInstance<TextAnalyticTopicActionData>(apiAnalysis, actionType);
                topicActionData.Add(textToAnalyse);
                return apiAnalysis;
            }
            var actionData = GetOrCreateActionInstance<TextAnalyticActionData>(apiAnalysis, actionType);
            actionData.Add(actionType, textToAnalyse);
            return apiAnalysis;
        }
    }
}
