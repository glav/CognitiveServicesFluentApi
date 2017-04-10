using Glav.CognitiveServices.FluentApi.TextAnalytic;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.TextAnalytic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests
{
    public class SentimentAnalysisApiTests
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
        }

        [Fact]
        public async Task SimplePositiveTextShouldReturnPositiveResultsUsingExtensions()
        {
            var result = await ConfigurationBuilder.CreateUsingApiKey(TestConfig.TextAnalyticsApiKey)
                .UsingHttpCommunication()
                .WithSentimentAnalysis("I am having a fantastic time.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
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
        }

        [Fact]
        public async Task SimpleNegativeTextShouldReturnNegativeResultsUsingExtensions()
        {
            var result = await ConfigurationBuilder.CreateUsingApiKey(TestConfig.TextAnalyticsApiKey)
                .UsingHttpCommunication()
                .WithSentimentAnalysis("I am having a terrible time.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
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

    }
}
 