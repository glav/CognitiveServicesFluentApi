using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System.Linq;
using Glav.CognitiveServices.Api.Fluent.Contracts;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.Api.Fluent
{
    public static class TextAnalyticFluentApiExtensions
    {
        public static ApiAnalysisSettings WithSentimentAnalysis(this ApiAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsSentiment);
        }

        public static ApiAnalysisSettings WithKeyPhraseAnalysis(this ApiAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsKeyphrases);
        }

        public static ApiAnalysisSettings WithKeyLanguageAnalysis(this ApiAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsLanguages);
        }

        public static ApiAnalysisSettings WithKeyTopicAnalysis(this ApiAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsTopics);
        }

        public static ApiAnalysisSettings WithKeyTopicAnalysis(this ApiAnalysisSettings apiAnalysis, string textToAnalyse, IEnumerable<string> topicsToExclude)
        {
            var actionData = GetOrCreateActionInstance<TextAnalyticTopicActionData>(apiAnalysis, ApiActionType.TextAnalyticsTopics);
            actionData.Add(textToAnalyse);
            return apiAnalysis;//.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsTopics);
        }

        private static T GetOrCreateActionInstance<T>(ApiAnalysisSettings apiAnalysis, ApiActionType actionType) where T : class, IApiActionData, new()
        {
            if (apiAnalysis.ActionsToPerform.ContainsKey(actionType))
            {
                return apiAnalysis.ActionsToPerform[actionType] as T;
            }

            var data = new T();
            apiAnalysis.ActionsToPerform.Add(actionType, data);
            return data;

        }
        private static ApiAnalysisSettings AddTextForAnalysis(this ApiAnalysisSettings apiAnalysis, string textToAnalyse, ApiActionType actionType)
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
