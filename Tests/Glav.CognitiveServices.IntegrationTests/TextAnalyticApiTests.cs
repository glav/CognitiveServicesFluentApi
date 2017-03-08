using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests
{
    public class TextAnalyticApiTests
    {
        const string ApiKey = "636868abf46c47bc8e92306989e281cd";

        [Fact]
        public void SimplePositiveTextShouldAnalyseAsPositive()
        {
            var result = ConfigurationBuilder.CreateUsingApiKey(ApiKey)
                .WithSentimentAnalysis("I am having a fantastic time.")
                .AnalyseAllAsync().Result;

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult.Result);
            Assert.NotEmpty(result.TextAnalyticSentimentAnalysis.AnalysisResult.Result.documents);

            Assert.Equal(SentimentClassification.Positive, result.TextAnalyticSentimentAnalysis.AnalysisResult.Result.documents[0].SentimentClassification);
        }

        [Fact]
        public void SimpleNegativeTextShouldAnalyseAsNegative()
        {
            var result = ConfigurationBuilder.CreateUsingApiKey(ApiKey)
                .WithSentimentAnalysis("I am having a terrible time.")
                .AnalyseAllAsync().Result;

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult.Result);
            Assert.NotEmpty(result.TextAnalyticSentimentAnalysis.AnalysisResult.Result.documents);

            Assert.Equal(SentimentClassification.Negative, result.TextAnalyticSentimentAnalysis.AnalysisResult.Result.documents[0].SentimentClassification);
        }

        [Fact]
        public void SimplePhraseTextShouldAnalyseAsAtLeastOneKeyPhrase()
        {
            var result = ConfigurationBuilder.CreateUsingApiKey(ApiKey)
                .WithKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllAsync().Result;

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.Result);
            Assert.NotEmpty(result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.Result.documents);

            Assert.Equal<string>("basic sentence", result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.Result.documents[0].keyPhrases[0]);
        }

        [Fact]
        public void SimplePhraseAndSentimentTextShouldAnalysBothItems()
        {
            var result = ConfigurationBuilder.CreateUsingApiKey(ApiKey)
                .WithSentimentAnalysis("I am having a terrible time.")
                .WithKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllAsync().Result;

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
    }
}
 