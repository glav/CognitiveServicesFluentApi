using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api
{
    public class ApiAnalysisResults
    {
        public SentimentAnalysisSet TextAnalyticSentimentAnalysis { get; private set; }
        public KeyPhraseAnalysisSet TextAnalyticKeyPhraseAnalysis { get; private set; }

        public void SetResult(SentimentAnalysisSet textAnalyticAnalysis)
        {
            TextAnalyticSentimentAnalysis = textAnalyticAnalysis;
        }
        public void SetResult(KeyPhraseAnalysisSet textAnalyticAnalysis)
        {
            TextAnalyticKeyPhraseAnalysis = textAnalyticAnalysis;
        }
    }
}
