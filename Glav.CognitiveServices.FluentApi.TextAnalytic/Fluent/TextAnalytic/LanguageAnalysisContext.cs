using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.TextAnalytic
{
    public class LanguageAnalysisContext : IApiAnalysisContext<TextAnalyticActionData, LanguagesResult>
    {
        public LanguageAnalysisContext(TextAnalyticActionData actionData, LanguagesResult analysisResult)
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
        }
        public ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsLanguages; } }

        public TextAnalyticActionData AnalysisInput { get; private set; }

        public LanguagesResult AnalysisResult { get; private set; }
}
}
