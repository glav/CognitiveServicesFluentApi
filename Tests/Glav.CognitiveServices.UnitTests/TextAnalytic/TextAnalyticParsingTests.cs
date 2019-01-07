using Xunit;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.UnitTests.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class TextAnalyticParsingTests
    {
        [Fact]
        public void ShouldParseSentimentResultSuccessfully()
        {
            var input = "{\"documents\":[{\"score\":0.7988085,\"id\":\"1\"}],\"errors\":[]}";
            var result = new SentimentResult(new MockCommsResult(input));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.NotEmpty(result.ResponseData.documents);
            Assert.Equal<long>(1, result.ResponseData.documents[0].id);
            Assert.Equal<double>(0.7988085, result.ResponseData.documents[0].score);
            Assert.Empty(result.ResponseData.errors);
        }

        [Fact]
        public void ShouldParseErrorResultResponseSuccessfully()
        {
            var input = "{\"code\":\"BadRequest\",\"message\":\"Invalid request\",\"innerError\":{\"code\":\"InvalidRequestBodyFormat\",\"message\":\"Request body format is wrong.Make sure the json request is serialized correctly and there are no null members.\"}}";
            var result = new SentimentResult(new MockCommsResult(input,System.Net.HttpStatusCode.BadRequest));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.False(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.NotEmpty(result.ResponseData.errors);
            Assert.Equal(1, result.ResponseData.errors.Length);
            Assert.Equal("BadRequest", result.ResponseData.errors[0].code);
            Assert.Equal("Invalid request", result.ResponseData.errors[0].message);
            Assert.NotNull(result.ResponseData.errors[0].InnerError);
            Assert.Equal("InvalidRequestBodyFormat", result.ResponseData.errors[0].InnerError.code);
            Assert.Equal("Request body format is wrong.Make sure the json request is serialized correctly and there are no null members.", result.ResponseData.errors[0].InnerError.message);
        }

        [Fact]
        public async Task ShouldParseErrorResultViaPipelineSuccessfully()
        {
            var input = "{\"code\":\"BadRequest\",\"message\":\"Invalid request\",\"innerError\":{\"code\":\"InvalidRequestBodyFormat\",\"message\":\"Request body format is wrong.Make sure the json request is serialized correctly and there are no null members.\"}}";
            var mockCommsEngine = new MockCommsEngine(new MockCommsResult(input));
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("test", LocationKeyIdentifier.WestUs)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(mockCommsEngine)
                .WithTextAnalyticAnalysisActions()
                .AddLanguageAnalysis("some rubbish")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.False(result.LanguageAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            var errMsg = result.LanguageAnalysis.GetInitialErrorMessage();
            Assert.NotNull(errMsg);
            Assert.Equal("Invalid request", errMsg);
        }

        [Fact]
        public void ShouldParseKeyPhraseResultSuccessfully()
        {
            var input = "{\"documents\":[{\"keyPhrases\":[\"phrase1\",\"phrase2\"],\"id\":\"1\"}],\"errors\":[]}";
            var result = new KeyPhraseResult(new MockCommsResult(input));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.NotEmpty(result.ResponseData.documents);
            Assert.NotEmpty(result.ResponseData.documents[0].keyPhrases);
            Assert.Equal<int>(2, result.ResponseData.documents[0].keyPhrases.Length);
            Assert.Equal<string>("phrase1", result.ResponseData.documents[0].keyPhrases[0]);
            Assert.Equal<string>("phrase2", result.ResponseData.documents[0].keyPhrases[1]);

            Assert.Empty(result.ResponseData.errors);
        }

        [Fact]
        public async Task ShouldFlattenAllKeyPhraseResultsSuccessfully()
        {
            var input = "{\"documents\":[{\"keyPhrases\":[\"phrase1\",\"phrase2\"],\"id\":\"1\"},{\"keyPhrases\":[\"phrase3\",\"phrase4\"],\"id\":\"2\"}],\"errors\":[]}";
            var commsEngine = new MockCommsEngine(new MockCommsResult(input));
            var logger = new TestLogger();

            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("test", LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddCustomDiagnosticLogging(logger)
                .UsingCustomCommunication(commsEngine)
                .WithTextAnalyticAnalysisActions()
                .AddKeyPhraseAnalysis("Can be anything here")
                .AnalyseAllAsync();

            Assert.NotEmpty(result.KeyPhraseAnalysis.AnalysisResults);
            var phraseResults = result.KeyPhraseAnalysis.GetResults();
            Assert.NotEmpty(phraseResults);
            Assert.Equal(2, phraseResults.Count());

            var allKeyphrases = result.KeyPhraseAnalysis.GetAllKeyPhrases().ToArray();
            Assert.NotEmpty(allKeyphrases);
            Assert.Equal(4, allKeyphrases.Length);
            Assert.Equal("phrase1", allKeyphrases[0]);
            Assert.Equal("phrase2", allKeyphrases[1]);
            Assert.Equal("phrase3", allKeyphrases[2]);
            Assert.Equal("phrase4", allKeyphrases[3]);
        }

        [Fact]
        public async Task ShouldGetinitialErrorSuccessfully()
        {
            var input = "{\"code\":\"BadRequest\",\"message\":\"Invalid request\",\"innerError\":{\"code\":\"InvalidRequestBodyFormat\",\"message\":\"Request body format is wrong.Make sure the json request is serialized correctly and there are no null members.\"}}";
            var commsEngine = new MockCommsEngine(new MockCommsResult(input));
            var logger = new TestLogger();

            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("test", LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddCustomDiagnosticLogging(logger)
                .UsingCustomCommunication(commsEngine)
                .WithTextAnalyticAnalysisActions()
                .AddKeyPhraseAnalysis("Can be anything here")
                .AnalyseAllAsync();

            Assert.NotEmpty(result.KeyPhraseAnalysis.AnalysisResults);
            var phraseResults = result.KeyPhraseAnalysis.GetInitialErrorMessage();

        }

        [Fact]
        public async Task ShouldParseLanguageResultSuccessfully()
        {
            var langResult = "{\"documents\":[{\"id\":\"1\",\"detectedLanguages\":[{\"name\":\"English\",\"iso6391Name\":\"en\",\"score\":1.0}]}],\"errors\":[]}";
            var commsEngine = new MockCommsEngine(new MockCommsResult(langResult));
            var logger = new TestLogger();

            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("test", LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.None)
                .AddCustomDiagnosticLogging(logger)
                .UsingCustomCommunication(commsEngine)
                .WithTextAnalyticAnalysisActions()
                .AddLanguageAnalysis("Can be anything here")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.LanguageAnalysis);
            Assert.NotEmpty(result.LanguageAnalysis.AnalysisResults);

            var results = result.LanguageAnalysis.GetResults();
            Assert.NotNull(results);
            Assert.Equal(1, results.Count());
            Assert.NotEmpty(results.First().detectedLanguages);
            Assert.Equal(1, results.First().detectedLanguages.Length);
            Assert.Equal("English", results.First().detectedLanguages[0].name);
            Assert.Equal("en", results.First().detectedLanguages[0].iso6391name);
            Assert.Equal(1.0, results.First().detectedLanguages[0].score);
            Assert.Equal(1, results.First().detectedLanguages.Length);
        }

        [Fact]
        public async Task ShouldReturnResultsMatchingAConfidenceLevelDescriptor()
        {
            var langResult = "{\"documents\":[{\"id\":\"1\",\"detectedLanguages\":[{\"name\":\"English\",\"iso6391Name\":\"en\",\"score\":1.0}]}],\"errors\":[]}";
            var commsEngine = new MockCommsEngine(new MockCommsResult(langResult));
            var logger = new TestLogger();

            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("test", LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.None)
                .AddCustomDiagnosticLogging(logger)
                .UsingCustomCommunication(commsEngine)
                .WithTextAnalyticAnalysisActions()
                .AddLanguageAnalysis("Can be anything here")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.LanguageAnalysis);
            Assert.NotEmpty(result.LanguageAnalysis.AnalysisResults);

            var results = result.LanguageAnalysis.GetResultsThatContainConfidenceLevel(DefaultScoreLevels.Positive);
            Assert.NotNull(results);
            Assert.Equal(1, results.Count());
            Assert.NotEmpty(results.First().detectedLanguages);
            Assert.Equal(1, results.First().detectedLanguages.Length);
            Assert.Equal("English", results.First().detectedLanguages[0].name);
            Assert.Equal("en", results.First().detectedLanguages[0].iso6391name);
            Assert.Equal(1.0, results.First().detectedLanguages[0].score);
            Assert.Equal(1, results.First().detectedLanguages.Length);
        }


    }
}
