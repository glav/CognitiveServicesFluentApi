using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.TextAnalytic
{
    public class LanguageAnalysisApiTests
    {

        [Fact]
        public async Task SimplePhraseTextShouldAnalyseToEnglish()
        {
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.TextAnalyticsApiKey, LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithTextAnalyticAnalysisActions()
                .AddLanguageAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.LanguageAnalysis);
            Assert.NotNull(result.LanguageAnalysis.AnalysisResult);
            Assert.NotNull(result.LanguageAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.LanguageAnalysis.AnalysisResult.ResponseData.documents);
            Assert.NotNull(result.LanguageAnalysis.AnalysisResult.ResponseData.documents[0].detectedLanguage);

            Assert.Equal<string>("en", result.LanguageAnalysis.AnalysisResult.ResponseData.documents[0].detectedLanguage.iso6391name);
            Assert.Equal<string>("English", result.LanguageAnalysis.AnalysisResult.ResponseData.documents[0].detectedLanguage.name);
            Assert.Equal<double>(1, result.LanguageAnalysis.AnalysisResult.ResponseData.documents[0].detectedLanguage.confidenceScore);
        }
    }
}
 