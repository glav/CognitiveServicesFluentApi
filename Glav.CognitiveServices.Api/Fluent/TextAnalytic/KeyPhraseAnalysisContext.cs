using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Configuration;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
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
