using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Configuration;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public class TextAnalyticAnalysisKeyPhraseResultSet : IApiAnalysisSet<TextAnalyticApiAction, TextAnalyticKeyPhraseResult>
    {
        public TextAnalyticAnalysisKeyPhraseResultSet(TextAnalyticApiAction actionData, TextAnalyticKeyPhraseResult analysisResult)
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
        }
        public ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsSentiment; } }

        public TextAnalyticApiAction AnalysisInput { get; private set; }

        public TextAnalyticKeyPhraseResult AnalysisResult { get; private set; }
}
}
