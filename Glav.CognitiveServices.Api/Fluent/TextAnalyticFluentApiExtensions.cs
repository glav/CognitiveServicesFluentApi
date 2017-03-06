using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;

namespace Glav.CognitiveServices.Api.Fluent
{
    public static class TextAnalyticFluentApiExtensions
    {
        public static ApiAnalysisSettings WithSentimentAnalysis(this ApiAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            var data = new TextAnalyticActionData();
            data.Add(ApiActionType.TextAnalyticsSentiment,textToAnalyse);
            apiAnalysis.ActionsToPerform.Add(new TextAnalyticApiAction(ApiActionType.TextAnalyticsSentiment,data));
            return apiAnalysis;
        }

        public static ApiAnalysisSettings WithKeyPhraseAnalysis(this ApiAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            var data = new TextAnalyticActionData();
            data.Add(ApiActionType.TextAnalyticsKeyphrases, textToAnalyse);
            apiAnalysis.ActionsToPerform.Add(new TextAnalyticApiAction(ApiActionType.TextAnalyticsKeyphrases,data));
            return apiAnalysis;
        }
    }
}
