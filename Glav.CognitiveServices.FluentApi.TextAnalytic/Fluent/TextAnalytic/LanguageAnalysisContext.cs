using Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.TextAnalytic
{
    public class LanguageAnalysisContext : IApiAnalysisContext<TextAnalyticActionData, LanguagesResult>
    {
        public LanguageAnalysisContext(TextAnalyticActionData actionData, LanguagesResult analysisResult)
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
        }
        public ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsSentiment; } }

        public TextAnalyticActionData AnalysisInput { get; private set; }

        public LanguagesResult AnalysisResult { get; private set; }
}
}
