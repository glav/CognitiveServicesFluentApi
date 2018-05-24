using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
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
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.SentimentAnalysis);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.SentimentAnalysis.AnalysisResult.ResponseData.documents);

            Assert.Equal(DefaultScoreLevels.Positive, result.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine.EvaluateScore(result.SentimentAnalysis.AnalysisResult.ResponseData.documents[0].score).Name);
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
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.Equal(1, result.SentimentAnalysis.NumberOfResponses(DefaultScoreLevels.Positive));

            // Get Original Id of input data
            var submittedId = result.SentimentAnalysis.AnalysisInput.GetAllItems().First().Id;
            var resultById = result.SentimentAnalysis.GetResult(submittedId);
            Assert.NotNull(resultById);
            Assert.Equal(DefaultScoreLevels.Positive, result.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine.EvaluateScore(resultById.score).Name);

            var collectedResults = result.SentimentAnalysis.GetResults(DefaultScoreLevels.Positive);
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
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.SentimentAnalysis);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.SentimentAnalysis.AnalysisResult.ResponseData.documents);

            Assert.Equal(DefaultScoreLevels.Negative, result.SentimentAnalysis.ScoringEngine.EvaluateScore(result.SentimentAnalysis.AnalysisResult.ResponseData.documents[0].score).Name);
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
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.Equal(1, result.SentimentAnalysis.NumberOfResponses(DefaultScoreLevels.Negative));

            // Get Original Id of input data
            var submittedId = result.SentimentAnalysis.AnalysisInput.GetAllItems().First().Id;
            var resultById = result.SentimentAnalysis.GetResult(submittedId);
            Assert.NotNull(resultById);
            Assert.Equal(DefaultScoreLevels.Negative, result.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine.EvaluateScore(resultById.score).Name);

            var collectedResults = result.SentimentAnalysis.GetResults(DefaultScoreLevels.Negative);
            Assert.NotNull(collectedResults);
            Assert.Equal(1, collectedResults.Count());
        }

        [Fact]
        public async Task ShouldHandleMultipleAnalysisItemsOfSameType()
        {
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.TextAnalyticsApiKey, LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("I am having a terrible time.")
                .AddSentimentAnalysis("This is really good")
                .AddSentimentAnalysis("This is absolutely fantastic")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.Equal(1, result.SentimentAnalysis.NumberOfResponses(DefaultScoreLevels.Negative));
            Assert.Equal(2, result.SentimentAnalysis.NumberOfResponses(DefaultScoreLevels.Positive));

            // Get Original Id of one item of input data
            var submittedId = result.SentimentAnalysis.AnalysisInput.GetAllItems().ToArray()[1].Id;
            var resultById = result.SentimentAnalysis.GetResult(submittedId);
            Assert.NotNull(resultById);
            Assert.Equal(DefaultScoreLevels.Positive, result.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine.EvaluateScore(resultById.score).Name);

        }
    }
}
 