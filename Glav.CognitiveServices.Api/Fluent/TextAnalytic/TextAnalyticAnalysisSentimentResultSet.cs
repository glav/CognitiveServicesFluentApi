using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.Api.Configuration;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public class TextAnalyticAnalysisSentimentResultSet : IApiAnalysisSet<TextAnalyticApiAction, TextAnalyticSentimentResult>
    {
        public TextAnalyticAnalysisSentimentResultSet(TextAnalyticApiAction actionData, TextAnalyticSentimentResult analysisResult)
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
        }
        public ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsSentiment; } }

        public TextAnalyticApiAction AnalysisInput { get; private set; }

        public TextAnalyticSentimentResult AnalysisResult { get; private set; }
}
}
