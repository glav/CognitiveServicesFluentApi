using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public class TextAnalyticAnalysisResults : IAnalysisResults
    {
        public TextAnalyticAnalysisResults(CoreAnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public CoreAnalysisSettings AnalysisSettings { get; private set;}

        public SentimentAnalysisContext SentimentAnalysis { get; private set; }
        public KeyPhraseAnalysisContext KeyPhraseAnalysis { get; private set; }

        public LanguageAnalysisContext LanguageAnalysis { get; private set; }

        public void SetResult(SentimentAnalysisContext sentimentAnalysis)
        {
            SentimentAnalysis = sentimentAnalysis;
        }
        public void SetResult(KeyPhraseAnalysisContext keyPhraseAnalysis)
        {
            KeyPhraseAnalysis = keyPhraseAnalysis;
        }
        public void SetResult(LanguageAnalysisContext languageAnalysis)
        {
            LanguageAnalysis = languageAnalysis;
        }
    }
}
