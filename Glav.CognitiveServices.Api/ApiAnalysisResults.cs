using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api
{
    public class ApiAnalysisResults
    {
        public TextAnalyticAnalysisSentimentResultSet TextAnalyticSentimentAnalysis { get; private set; }
        public TextAnalyticAnalysisKeyPhraseResultSet TextAnalyticKeyPhraseAnalysis { get; private set; }

        public static ApiAnalysisResults Create(TextAnalyticAnalysisSentimentResultSet textAnalyticAnalysis)
        {
            return new ApiAnalysisResults { TextAnalyticSentimentAnalysis = textAnalyticAnalysis };
        }
        public static ApiAnalysisResults Create(TextAnalyticAnalysisKeyPhraseResultSet textAnalyticAnalysis)
        {
            return new ApiAnalysisResults { TextAnalyticKeyPhraseAnalysis = textAnalyticAnalysis };
        }
    }
}
