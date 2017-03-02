using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;

namespace Glav.CognitiveServices.Api.Fluent
{
    public static class TextAnalyticFluentApi
    {
        public static ApiAnalysisSettings WithSentimentAnalysis(this ApiAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            var data = new TextAnalyticActionData();
            data.Add(textToAnalyse);
            apiAnalysis.ActionsToPerform.Add(new TextAnalyticApiAction(data));
            return apiAnalysis;
        }
    }
}
