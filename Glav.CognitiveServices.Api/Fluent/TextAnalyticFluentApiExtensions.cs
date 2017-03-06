using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System.Linq;

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

        private static ApiAnalysisSettings AddTextForAnalysis(this ApiAnalysisSettings apiAnalysis, string textToAnalyse, ApiActionType actionType)
        {
            if (apiAnalysis.ActionsToPerform.ContainsKey(actionType))
            {
                var textAnalyticAction = apiAnalysis.ActionsToPerform[actionType] as TextAnalyticActionData;
                textAnalyticAction.Add(actionType, textToAnalyse);
                return apiAnalysis;
            }

            var data = new TextAnalyticActionData();
            data.Add(actionType, textToAnalyse);
            apiAnalysis.ActionsToPerform.Add(actionType, data);
            return apiAnalysis;
        }
    }
}
