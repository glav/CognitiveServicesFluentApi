using Glav.CognitiveServices.Api;
using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests
{
    public class TextAnalyticApiTests
    {
        [Fact]
        public async Task SimplePositiveTextShouldAnalyseAsPositive()
        {
            var result = await ConfigurationBuilder.CreateUsingApiKey(TestConfig.TextAnalyticsApiKey)
                .UsingHttpCommunication()
                .WithSentimentAnalysis("I am having a fantastic time.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.TextAnalyticSentimentAnalysis.AnalysisResult.ResponseData.documents);

            Assert.Equal(SentimentClassification.Positive, result.TextAnalyticSentimentAnalysis.AnalysisResult.ResponseData.documents[0].SentimentClassification);
            Assert.Equal(1, result.TextAnalyticSentimentAnalysis.NumberOfResponses(SentimentClassification.Positive));

            // Get Original Id of input data
            var submittedId = result.TextAnalyticSentimentAnalysis.AnalysisInput.GetAllItems()[0].Id;
            var resultById = result.TextAnalyticSentimentAnalysis.GetResult(submittedId);
            Assert.NotNull(resultById);
            Assert.Equal(SentimentClassification.Positive, resultById.SentimentClassification);

            var collectedResults = result.TextAnalyticSentimentAnalysis.GetResults(SentimentClassification.Positive);
            Assert.NotNull(collectedResults);
            Assert.Equal(1, collectedResults.Count());
        }

        [Fact]
        public async Task SimpleNegativeTextShouldAnalyseAsNegative()
        {
            var result = await ConfigurationBuilder.CreateUsingApiKey(TestConfig.TextAnalyticsApiKey)
                .UsingHttpCommunication()
                .WithSentimentAnalysis("I am having a terrible time.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.TextAnalyticSentimentAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.TextAnalyticSentimentAnalysis.AnalysisResult.ResponseData.documents);

            Assert.Equal(SentimentClassification.Negative, result.TextAnalyticSentimentAnalysis.AnalysisResult.ResponseData.documents[0].SentimentClassification);
            Assert.Equal(1, result.TextAnalyticSentimentAnalysis.NumberOfResponses(SentimentClassification.Negative));

            // Get Original Id of input data
            var submittedId = result.TextAnalyticSentimentAnalysis.AnalysisInput.GetAllItems()[0].Id;
            var resultById = result.TextAnalyticSentimentAnalysis.GetResult(submittedId);
            Assert.NotNull(resultById);
            Assert.Equal(SentimentClassification.Negative, resultById.SentimentClassification);

            var collectedResults = result.TextAnalyticSentimentAnalysis.GetResults(SentimentClassification.Negative);
            Assert.NotNull(collectedResults);
            Assert.Equal(1, collectedResults.Count());
        }

        [Fact]
        public async Task SimplePhraseTextShouldAnalyseAsAtLeastOneKeyPhrase()
        {
            var result = await ConfigurationBuilder.CreateUsingApiKey(TestConfig.TextAnalyticsApiKey)
                .UsingHttpCommunication()
                .WithKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllAsync();

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
            var result = await ConfigurationBuilder.CreateUsingApiKey(TestConfig.TextAnalyticsApiKey)
                .UsingHttpCommunication()
                .WithSentimentAnalysis("I am having a terrible time.")
                .WithKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllAsync();

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
            var result = await ConfigurationBuilder.CreateUsingApiKey(TestConfig.TextAnalyticsApiKey)
                .UsingHttpCommunication()
                .WithKeyLanguageAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllAsync();

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

        [Fact]
        public async Task SimpleTopicsShouldAnalyseAndBeDetected()
        {
            var config = ConfigurationBuilder.CreateUsingApiKey(TestConfig.TextAnalyticsApiKey)
                .UsingHttpCommunication();

            //Build up at least 100 documents as the service requires a minimum of 100
            for (var cnt = 0; cnt < 100; cnt++)
            {
                config.WithKeyTopicAnalysis($"This is line {cnt} for a block of text on numbers.");
            }

            var analysisResult = await config.AnalyseAllAsync();

            Assert.NotNull(analysisResult);
            Assert.NotNull(analysisResult.TextAnalyticTopicAnalysis);
            Assert.NotNull(analysisResult.TextAnalyticTopicAnalysis.AnalysisResult);
            Assert.NotNull(analysisResult.TextAnalyticTopicAnalysis.AnalysisResult.ResponseData);
            Assert.NotNull(analysisResult.TextAnalyticTopicAnalysis.AnalysisResult.ApiCallResult.OperationLocationUri);

            var checkResult = await analysisResult.CheckTopicAnalysisStatusAsync();

        }
    }
}
 