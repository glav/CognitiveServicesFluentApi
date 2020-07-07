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
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, TextAnalyticApiOperations.SentimentAnalysis);
        }

        public static TextAnalyticAnalysisSettings AddKeyPhraseAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, TextAnalyticApiOperations.KeyPhraseAnalysis);
        }

        public static TextAnalyticAnalysisSettings AddLanguageAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            return apiAnalysis.AddTextForAnalysis(textToAnalyse, TextAnalyticApiOperations.LanguageAnalysis);
        }


        private static TextAnalyticAnalysisSettings AddTextForAnalysis(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse, ApiActionDefinition actionType)
        {
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<TextAnalyticActionData>(actionType);
            actionData.Add(actionType, textToAnalyse);
            return apiAnalysis;
        }
    }
}
