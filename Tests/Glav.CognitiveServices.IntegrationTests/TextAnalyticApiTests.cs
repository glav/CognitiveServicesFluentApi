using Glav.CognitiveServices.Api;
using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests
{
    public class TextAnalyticApiTests
    {
        const string ApiKey = "636868abf46c47bc8e92306989e281cd";

        [Fact]
        public async Task SimplePositiveTextShouldAnalyseAsPositive()
        {
            var result = await ConfigurationBuilder.CreateUsingApiKey(ApiKey)
                .WithSentimentAnalysis("I am having a fantastic time.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult.Result);
            Assert.NotEmpty(result.TextAnalyticSentimentAnalysis.AnalysisResult.Result.documents);

            Assert.Equal(SentimentClassification.Positive, result.TextAnalyticSentimentAnalysis.AnalysisResult.Result.documents[0].SentimentClassification);
        }

        [Fact]
        public async Task SimpleNegativeTextShouldAnalyseAsNegative()
        {
            var result = await ConfigurationBuilder.CreateUsingApiKey(ApiKey)
                .WithSentimentAnalysis("I am having a terrible time.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult.Result);
            Assert.NotEmpty(result.TextAnalyticSentimentAnalysis.AnalysisResult.Result.documents);

            Assert.Equal(SentimentClassification.Negative, result.TextAnalyticSentimentAnalysis.AnalysisResult.Result.documents[0].SentimentClassification);
        }

        [Fact]
        public async Task SimplePhraseTextShouldAnalyseAsAtLeastOneKeyPhrase()
        {
            var result = await ConfigurationBuilder.CreateUsingApiKey(ApiKey)
                .WithKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.Result);
            Assert.NotEmpty(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.Result.documents);

            Assert.Equal<string>("basic sentence", result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.Result.documents[0].keyPhrases[0]);
        }

        [Fact]
        public async Task SimplePhraseAndSentimentTextShouldAnalysBothItems()
        {
            var result = await ConfigurationBuilder.CreateUsingApiKey(ApiKey)
                .WithSentimentAnalysis("I am having a terrible time.")
                .WithKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.Result);
            Assert.NotEmpty(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.Result.documents);
            Assert.Equal<string>("basic sentence", result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.Result.documents[0].keyPhrases[0]);

            Assert.NotNull(result.TextAnalyticSentimentAnalysis);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult.Result);
            Assert.NotEmpty(result.TextAnalyticSentimentAnalysis.AnalysisResult.Result.documents);
            Assert.Equal(SentimentClassification.Negative, result.TextAnalyticSentimentAnalysis.AnalysisResult.Result.documents[0].SentimentClassification);
        }

        [Fact]
        public async Task SimplePhraseTextShouldAnalyseToEnglish()
        {
            var result = await ConfigurationBuilder.CreateUsingApiKey(ApiKey)
                .WithKeyLanguageAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticLanguageAnalysis);
            Assert.NotNull(result.TextAnalyticLanguageAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticLanguageAnalysis.AnalysisResult.Result);
            Assert.NotEmpty(result.TextAnalyticLanguageAnalysis.AnalysisResult.Result.documents);
            Assert.NotEmpty(result.TextAnalyticLanguageAnalysis.AnalysisResult.Result.documents[0].detectedLanguages);

            Assert.Equal<string>("en", result.TextAnalyticLanguageAnalysis.AnalysisResult.Result.documents[0].detectedLanguages[0].iso6391name);
            Assert.Equal<string>("English", result.TextAnalyticLanguageAnalysis.AnalysisResult.Result.documents[0].detectedLanguages[0].name);
            Assert.Equal<double>(1, result.TextAnalyticLanguageAnalysis.AnalysisResult.Result.documents[0].detectedLanguages[0].score);
        }
    }
}
 