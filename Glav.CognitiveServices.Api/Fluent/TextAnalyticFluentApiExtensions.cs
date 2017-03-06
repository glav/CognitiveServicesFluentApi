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
            if (apiAnalysis.ActionsToPerform.Keys.Contains(ApiActionType.TextAnalyticsSentiment))
            {
                var textAnalyticAction = apiAnalysis.ActionsToPerform[ApiActionType.TextAnalyticsSentiment] as TextAnalyticActionData;
                textAnalyticAction.Add(ApiActionType.TextAnalyticsSentiment, textToAnalyse);
                return apiAnalysis;
            }

            var data = new TextAnalyticActionData();
            data.Add(ApiActionType.TextAnalyticsSentiment, textToAnalyse);
            apiAnalysis.ActionsToPerform.Add(ApiActionType.TextAnalyticsSentiment, data);
            return apiAnalysis;
        }

        public static ApiAnalysisSettings WithKeyPhraseAnalysis(this ApiAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            if (apiAnalysis.ActionsToPerform.Keys.Contains(ApiActionType.TextAnalyticsKeyphrases))
            {
                var textAnalyticAction = apiAnalysis.ActionsToPerform[ApiActionType.TextAnalyticsKeyphrases] as TextAnalyticActionData;
                textAnalyticAction.Add(ApiActionType.TextAnalyticsKeyphrases, textToAnalyse);
                return apiAnalysis;
            }

            var data = new TextAnalyticActionData();
            data.Add(ApiActionType.TextAnalyticsKeyphrases, textToAnalyse);
            apiAnalysis.ActionsToPerform.Add(ApiActionType.TextAnalyticsKeyphrases,data);
            return apiAnalysis;
        }
    }
}
