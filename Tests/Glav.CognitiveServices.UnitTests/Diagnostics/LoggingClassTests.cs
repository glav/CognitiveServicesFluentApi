using Xunit;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.UnitTests.Diagnostics
{
    public class LoggingClassTests
    {
        [Fact]
        public void InformationalLoggingMessageShouldNotBePerformed()
        {
            var logger = new TestLogger();

            var mockCommsEngine = new MockCommsEngine(new MockCommsResult("{ \"code\":\"Bad Request\"}", System.Net.HttpStatusCode.BadRequest));
            var result = TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("test", LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddCustomDiagnosticLogging(logger)
                .UsingDefaultScoringEngineAndScoreLevels()
                .UsingCustomCommunication(mockCommsEngine)
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("this should not log some informational messages")
                .AnalyseAllSentimentsAsync();

            Assert.Equal<int>(0, logger.NumberOfLogInfoMessages);
                
        }

        [Fact]
        public void InformationalLoggingMessageShouldBePerformed()
        {
            var logger = new TestLogger();

            var mockCommsEngine = new MockCommsEngine(new MockCommsResult("{ \"code\":\"Bad Request\"}", System.Net.HttpStatusCode.BadRequest));
            var result = TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("test", LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddCustomDiagnosticLogging(logger)
                .UsingCustomCommunication(mockCommsEngine)
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("This should log some informational messages")
                .AnalyseAllSentimentsAsync();

            Assert.True(logger.NumberOfLogInfoMessages > 0);

        }
    }
}
