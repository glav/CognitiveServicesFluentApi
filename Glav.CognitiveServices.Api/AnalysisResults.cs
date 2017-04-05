using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api
{
    public class AnalysisResults
    {
        private readonly AnalysisSettings _analysisSettings;

        public AnalysisResults(AnalysisSettings analysisSettings)
        {
            _analysisSettings = analysisSettings;
        }
        public AnalysisSettings AnalysisSettings { get { return _analysisSettings; } }

        public SentimentAnalysisContext TextAnalyticSentimentAnalysis { get; private set; }
        public KeyPhraseAnalysisContext TextAnalyticKeyPhraseAnalysis { get; private set; }
        public TopicAnalysisContext TextAnalyticTopicAnalysis { get; private set; }

        public LanguageAnalysisContext TextAnalyticLanguageAnalysis { get; private set; }

        public void SetResult(SentimentAnalysisContext textAnalyticAnalysis)
        {
            TextAnalyticSentimentAnalysis = textAnalyticAnalysis;
        }
        public void SetResult(KeyPhraseAnalysisContext textAnalyticAnalysis)
        {
            TextAnalyticKeyPhraseAnalysis = textAnalyticAnalysis;
        }
        public void SetResult(LanguageAnalysisContext textAnalyticAnalysis)
        {
            TextAnalyticLanguageAnalysis = textAnalyticAnalysis;
        }
        public void SetResult(TopicAnalysisContext textAnalyticAnalysis)
        {
            TextAnalyticTopicAnalysis = textAnalyticAnalysis;
        }
    }
}
