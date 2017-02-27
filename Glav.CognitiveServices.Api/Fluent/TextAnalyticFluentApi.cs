using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public static class TextAnalyticFluentApi
    {
        public static ApiAnalysisSettings WithSentimentAnalysis(this ApiAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            apiAnalysis.ActionsToPerform.Add(new ApiAction(ApiActionType.TextAnalyticsSentiment,textToAnalyse));
            return apiAnalysis;
        }
    }
}
