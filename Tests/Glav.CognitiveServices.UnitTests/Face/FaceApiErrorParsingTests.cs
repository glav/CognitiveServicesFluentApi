using Xunit;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Face;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    /// <summary>
    /// Class that tests each Api result that results in an error is parsed correctly. it ensures that the ApiResult class uses the parsing 
    /// strategy correctly.
    /// </summary>
    public class FaceApiErrorParsingTests
    {
        private TestDataHelper _helper = new TestDataHelper();
        private readonly string _inputData;

        public FaceApiErrorParsingTests()
        {
            _inputData = _helper.GetFileDataEmbeddedInAssembly("FaceApiErrorResponse.json");
        }
        [Fact]
        public async Task ShouldParseLargePersonGroupCreateError()
        {
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("some key", LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddConsoleAndTraceLogging()
                .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                .WithFaceAnalysisActions()
                .CreateLargePersonGroup("$@#!", "should fail")
                .AnalyseAllAsync();

            ResponseErrorAssertion(result, result.LargePersonGroupCreateAnalysis);
        }

        [Fact]
        public async Task ShouldParsefaceIdentificationError()
        {
            var identifyResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .IdentifyFace("123", "456")
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(identifyResult, identifyResult.FaceIdentificationAnalysis);
        }

        [Fact]
        public async Task ShouldParsefaceDetectionError()
        {
            var detectResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("whatevs", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .AddUriForFaceDetection(new System.Uri("http://blah/blah/blah.jpg"), FaceDetectionAttributes.Age)
                                       .AnalyseAllAsync();
            ResponseErrorAssertion(detectResult, detectResult.FaceDetectionAnalysis);
        }

        [Fact]
        public async Task ShouldParseLargePersonDeleteError()
        {
            var deleteResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("heyho", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .DeleteLargePersonGroup("Notexists")
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(deleteResult, deleteResult.LargePersonGroupDeleteAnalysis);
        }

        [Fact]
        public async Task ShouldParseLargePersonGetError()
        {
            var getResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("biteme", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .GetLargePersonGroup("not here")
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(getResult, getResult.LargePersonGroupGetAnalysis);
        }

        [Fact]
        public async Task ShouldParseLargePersonListError()
        {
            var listResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("eeek", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .ListLargePersonGroups(new string('*', 1000))
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(listResult, listResult.LargePersonGroupListAnalysis);
        }

        [Fact]
        public async Task ShouldParseLargePersonStartTrainError()
        {
            var trainResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("eeek", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .StartTrainingLargePersonGroup("123")
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(trainResult, trainResult.LargePersonGroupTrainStartAnalysis);
        }

        [Fact]
        public async Task ShouldParseLargePersonStartStatusError()
        {
            var trainResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("eeek", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .CheckTrainingStatusLargePersonGroup("123")
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(trainResult, trainResult.LargePersonGroupTrainStatusAnalysis);
        }

        private static void ResponseErrorAssertion(IAnalysisResults root, dynamic analysisContext)
        {
            Assert.NotNull(root);
            Assert.NotNull(analysisContext);
            Assert.NotEmpty(analysisContext.AnalysisResults);
            Assert.NotNull(analysisContext.AnalysisResult.ResponseData);
            Assert.NotNull(analysisContext.AnalysisResult.ResponseData.error);
            Assert.Equal("BadArgument", analysisContext.AnalysisResult.ResponseData.error.code);

        }


    }
}


