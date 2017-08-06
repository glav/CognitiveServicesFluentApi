using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.TextAnalytic
{
    public class SentimentAnalysisApiTests
    {
        [Fact]
        public async Task SimplePositiveTextShouldAnalyseAsPositive()
        {
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.TextAnalyticsApiKey, LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("I am having a fantastic time.")
                .AnalyseAllSentimentsAsync();

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
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.TextAnalyticsApiKey, LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("I am having a fantastic time.")
                .AnalyseAllSentimentsAsync();

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
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.TextAnalyticsApiKey, LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("I am having a terrible time.")
                .AnalyseAllSentimentsAsync();

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
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.TextAnalyticsApiKey, LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("I am having a terrible time.")
                .AnalyseAllSentimentsAsync();

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
 