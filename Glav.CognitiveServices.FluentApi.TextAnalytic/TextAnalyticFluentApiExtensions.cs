using System.Collections.Generic;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public static class TextAnalyticFluentApiExtensions
    {
        public static async Task<TextAnalyticAnalysisResults> AnalyseAllAsync(this TextAnalyticAnalysisSettings apiAnalysisSettings)
        {
            var engine = new TextAnalyticAnalysisEngine(apiAnalysisSettings);
            return await engine.AnalyseAllAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public static TextAnalyticAnalysisSettings AddSentimentAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsSentiment);
        }

        public static TextAnalyticAnalysisSettings AddSentimentAnalysisSplitIntoSentences(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            var sentences = textToAnalyse.SplitTextIntoSentences();
            sentences.ToList().ForEach(s =>
            {
                apiAnalysis.AddTextForAnalysis(s, ApiActionType.TextAnalyticsSentiment);
            });
            return apiAnalysis;
        }

        public static TextAnalyticAnalysisSettings AddKeyPhraseAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsKeyphrases);
        }

        public static TextAnalyticAnalysisSettings AddLanguageAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, ApiActionType.TextAnalyticsLanguages);
        }


        private static TextAnalyticAnalysisSettings AddTextForAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse, ApiActionType actionType)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<TextAnalyticActionData>(actionType);
            actionData.Add(actionType, textToAnalyse);
            return apiAnalysis;
        }
    }
}
