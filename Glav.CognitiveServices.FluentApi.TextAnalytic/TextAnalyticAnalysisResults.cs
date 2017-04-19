using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public class TextAnalyticAnalysisResults
    {
        public TextAnalyticAnalysisResults(AnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public AnalysisSettings AnalysisSettings { get; private set;}

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
