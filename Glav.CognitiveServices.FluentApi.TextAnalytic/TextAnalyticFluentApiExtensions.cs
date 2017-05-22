using System.Collections.Generic;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public static class TextAnalyticFluentApiExtensions
    {
        public static async Task<TextAnalyticAnalysisResults> AnalyseAllSentimentsAsync(this TextAnalyticAnalysisSettings apiAnalysisSettings)
        {
            var engine = new TextAnalyticAnalysisEngine(apiAnalysisSettings);
            return await engine.AnalyseAllAsync();
        }

        public static TextAnalyticAnalysisSettings AddSentimentAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsSentiment);
        }

        public static TextAnalyticAnalysisSettings AddKeyPhraseAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsKeyphrases);
        }

        public static TextAnalyticAnalysisSettings AddKeyLanguageAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsLanguages);
        }

        public static TextAnalyticAnalysisSettings AddKeyTopicAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsTopics);
        }
        public static TextAnalyticAnalysisSettings AddKeyTopicAnalysisSplittingDataIntoSentences(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            var sentences = textToAnalyse.SplitTextIntoSentences();
            foreach(var sentence in sentences)
            {
                apiAnalysis.AddTextForAnalysis(sentence, ApiActionType.TextAnalyticsTopics);
            }
            return apiAnalysis;
            
        }

        public static TextAnalyticAnalysisSettings AddKeyTopicAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse, IEnumerable<string> topicsToExclude)
        {
            var actionData = GetOrCreateActionInstance<TextAnalyticTopicActionData>(apiAnalysis, ApiActionType.TextAnalyticsTopics);
            actionData.Add(textToAnalyse);
            return apiAnalysis;//.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsTopics);
        }

        private static T GetOrCreateActionInstance<T>(TextAnalyticAnalysisSettings apiAnalysis, ApiActionType actionType) where T : class, IApiActionData, new()
        {
            if (apiAnalysis.ActionsToPerform.ContainsKey(actionType))
            {
                return apiAnalysis.ActionsToPerform[actionType] as T;
            }

            var data = new T();
            apiAnalysis.ActionsToPerform.Add(actionType, data);
            return data;

        }
        private static TextAnalyticAnalysisSettings AddTextForAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse, ApiActionType actionType)
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
