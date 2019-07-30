using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.TextAnalytic
{
    public class ApiErrorHandlingTests
    {
        [Fact]
        public async Task InvalidApiKeyShouldbereflectedInErrorResults()
        {
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("some bogus key", LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("I am having a fantastic time.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.SentimentAnalysis);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult.ApiCallResult);
            Assert.False(result.SentimentAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.SentimentAnalysis.AnalysisResult.ResponseData.errors);
            Assert.Equal("401", result.SentimentAnalysis.AnalysisResult.ResponseData.errors[0].code);
        }

    }
}
 