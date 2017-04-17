using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.TextAnalytic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests
{
    public class KeyPhraseAnalysisApiTests
    {

        [Fact]
        public async Task SimplePhraseTextShouldAnalyseAsAtLeastOneKeyPhrase()
        {
            var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey(TestConfig.TextAnalyticsApiKey)
                .UsingHttpCommunication()
                .WithKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllSentimentsAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.ResponseData.documents);

            Assert.Equal<string>("basic sentence", result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.ResponseData.documents[0].keyPhrases[0]);
        }

        [Fact]
        public async Task SimplePhraseAndSentimentTextShouldAnalysBothItems()
        {
            var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey(TestConfig.TextAnalyticsApiKey)
                .UsingHttpCommunication()
                .WithSentimentAnalysis("I am having a terrible time.")
                .WithKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllSentimentsAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.ResponseData.documents);
            Assert.Equal<string>("basic sentence", result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.ResponseData.documents[0].keyPhrases[0]);

            Assert.NotNull(result.TextAnalyticSentimentAnalysis);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.TextAnalyticSentimentAnalysis.AnalysisResult.ResponseData.documents);
            Assert.Equal(SentimentClassification.Negative, result.TextAnalyticSentimentAnalysis.AnalysisResult.ResponseData.documents[0].SentimentClassification);
        }

        [Fact]
        public async Task SimplePhraseTextShouldAnalyseToEnglish()
        {
            var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey(TestConfig.TextAnalyticsApiKey)
                .UsingHttpCommunication()
                .WithKeyLanguageAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllSentimentsAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticLanguageAnalysis);
            Assert.NotNull(result.TextAnalyticLanguageAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticLanguageAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.TextAnalyticLanguageAnalysis.AnalysisResult.ResponseData.documents);
            Assert.NotEmpty(result.TextAnalyticLanguageAnalysis.AnalysisResult.ResponseData.documents[0].detectedLanguages);

            Assert.Equal<string>("en", result.TextAnalyticLanguageAnalysis.AnalysisResult.ResponseData.documents[0].detectedLanguages[0].iso6391name);
            Assert.Equal<string>("English", result.TextAnalyticLanguageAnalysis.AnalysisResult.ResponseData.documents[0].detectedLanguages[0].name);
            Assert.Equal<double>(1, result.TextAnalyticLanguageAnalysis.AnalysisResult.ResponseData.documents[0].detectedLanguages[0].score);
        }
    }
}
 