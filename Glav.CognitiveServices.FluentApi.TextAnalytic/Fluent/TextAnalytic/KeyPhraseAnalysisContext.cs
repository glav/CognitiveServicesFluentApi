using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.TextAnalytic
{
    public class KeyPhraseAnalysisContext : IApiAnalysisContext<TextAnalyticActionData, KeyPhraseResult>
    {
        public KeyPhraseAnalysisContext(TextAnalyticActionData actionData, KeyPhraseResult analysisResult)
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
        }
        public ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsSentiment; } }

        public TextAnalyticActionData AnalysisInput { get; private set; }

        public KeyPhraseResult AnalysisResult { get; private set; }
}
}
