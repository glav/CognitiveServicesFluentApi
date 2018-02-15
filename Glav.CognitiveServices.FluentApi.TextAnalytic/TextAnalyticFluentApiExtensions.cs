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
        public static async Task<TextAnalyticAnalysisResults> AnalyseAllAsync(this TextAnalyticAnalysisSettings apiAnalysisSettings)
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

        public static TextAnalyticAnalysisSettings AddLanguageAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsLanguages);
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
            var actionData = GetOrCreateActionInstance<TextAnalyticActionData>(apiAnalysis, actionType);
            actionData.Add(actionType, textToAnalyse);
            return apiAnalysis;
        }
    }
}
