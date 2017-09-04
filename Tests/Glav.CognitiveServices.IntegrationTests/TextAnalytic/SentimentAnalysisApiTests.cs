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
            Assert.NotNull(result.SentimentAnalysis);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.SentimentAnalysis.AnalysisResult.ResponseData.documents);

            Assert.Equal(SentimentClassification.Positive, result.SentimentAnalysis.AnalysisResult.ResponseData.documents[0].SentimentClassification);
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
            Assert.Equal(1, result.SentimentAnalysis.NumberOfResponses(SentimentClassification.Positive));

            // Get Original Id of input data
            var submittedId = result.SentimentAnalysis.AnalysisInput.GetAllItems()[0].Id;
            var resultById = result.SentimentAnalysis.GetResult(submittedId);
            Assert.NotNull(resultById);
            Assert.Equal(SentimentClassification.Positive, resultById.SentimentClassification);

            var collectedResults = result.SentimentAnalysis.GetResults(SentimentClassification.Positive);
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
            Assert.NotNull(result.SentimentAnalysis);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.SentimentAnalysis.AnalysisResult.ResponseData.documents);

            Assert.Equal(SentimentClassification.Negative, result.SentimentAnalysis.AnalysisResult.ResponseData.documents[0].SentimentClassification);
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
            Assert.Equal(1, result.SentimentAnalysis.NumberOfResponses(SentimentClassification.Negative));

            // Get Original Id of input data
            var submittedId = result.SentimentAnalysis.AnalysisInput.GetAllItems()[0].Id;
            var resultById = result.SentimentAnalysis.GetResult(submittedId);
            Assert.NotNull(resultById);
            Assert.Equal(SentimentClassification.Negative, resultById.SentimentClassification);

            var collectedResults = result.SentimentAnalysis.GetResults(SentimentClassification.Negative);
            Assert.NotNull(collectedResults);
            Assert.Equal(1, collectedResults.Count());
        }

    }
}
 