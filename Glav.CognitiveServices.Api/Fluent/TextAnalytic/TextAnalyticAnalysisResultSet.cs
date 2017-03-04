using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Configuration;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public class TextAnalyticAnalysisResultSet : IApiAnalysisSet<TextAnalyticApiAction, TextAnalyticActionResult>
    {
        public TextAnalyticAnalysisResultSet(TextAnalyticApiAction actionData, TextAnalyticActionResult analysisResult)
        {
            ActionData = actionData;
            AnalysisResult = analysisResult;
        }
        public ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsSentiment; } }

        public TextAnalyticApiAction ActionData { get; private set; }

        public TextAnalyticActionResult AnalysisResult { get; private set; }
}
}
