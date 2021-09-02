using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.TextAnalytic
{
    public class KeyPhraseAnalysisApiTests
    {

        [Fact]
        public async Task SimplePhraseTextShouldAnalyseAsAtLeastOneKeyPhrase()
        {
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.TextAnalyticsApiKey, LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithTextAnalyticAnalysisActions()
                .AddKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.KeyPhraseAnalysis);
            Assert.NotNull(result.KeyPhraseAnalysis.AnalysisResult);
            Assert.NotNull(result.KeyPhraseAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.KeyPhraseAnalysis.AnalysisResult.ResponseData.documents);

            Assert.Equal<string>("basic sentence", result.KeyPhraseAnalysis.AnalysisResult.ResponseData.documents[0].keyPhrases[0]);
        }

        [Fact]
        public async Task SimplePhraseAndSentimentTextShouldAnalysBothItems()
        {
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.TextAnalyticsApiKey, LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("I am having a terrible time.")
                .AddKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.KeyPhraseAnalysis);
            Assert.NotNull(result.KeyPhraseAnalysis.AnalysisResult);
            Assert.NotNull(result.KeyPhraseAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.KeyPhraseAnalysis.AnalysisResult.ResponseData.documents);
            Assert.Equal<string>("basic sentence", result.KeyPhraseAnalysis.AnalysisResult.ResponseData.documents[0].keyPhrases[0]);

            Assert.NotNull(result.SentimentAnalysis);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.SentimentAnalysis.AnalysisResult.ResponseData.documents);
            Assert.Equal("Negative", 
                result.SentimentAnalysis.ScoringEngine.Evaluate(result.SentimentAnalysis.AnalysisResult.ResponseData.documents[0]).Name);
        }
    }
}
 