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

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonCreateError()
        {
            var lpgpcResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("oops", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .CreateLargePersonGroupPerson("123","mopey")
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(lpgpcResult, lpgpcResult.LargePersonGroupPersonCreateAnalysis);
        }

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonDeleteError()
        {
            var lpgpdResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("oops", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .DeleteLargePersonGroupPerson("123", "mopey")
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(lpgpdResult, lpgpdResult.LargePersonGroupPersonDeleteAnalysis);
        }

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonFaceAddError()
        {
            var faceAddResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("oops", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .AddFaceToPersonGroupPerson("123", "mopey", new System.Uri("http://host/endpoint"))
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(faceAddResult, faceAddResult.LargePersonGroupPersonFaceAddAnalysis);
        }

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonFaceDeleteError()
        {
            var faceDelResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("oops", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .DeleteFaceForPersonGroupPerson("123", "mopey", "someface")
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(faceDelResult, faceDelResult.LargePersonGroupPersonFaceDeleteAnalysis);
        }

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonFaceGetError()
        {
            var faceGetResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("oops", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .GetFaceForPersonGroupPerson("123", "mopey", "someface")
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(faceGetResult, faceGetResult.LargePersonGroupPersonFaceGetAnalysis);
        }

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonGetError()
        {
            var getResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("oops", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .GetLargePersonGroupPerson("hoochey", "coochey" )
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(getResult, getResult.LargePersonGroupPersonGetAnalysis);
        }

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonListError()
        {
            var listResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys("oops", LocationKeyIdentifier.AustraliaEast)
                                       .AddConsoleAndTraceLogging()
                                       .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                                        .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(_inputData, System.Net.HttpStatusCode.BadRequest)))
                                       .WithFaceAnalysisActions()
                                       .ListLargePersonGroupPersons("some group")
                                       .AnalyseAllAsync();

            ResponseErrorAssertion(listResult, listResult.LargePersonGroupPersonListAnalysis);
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


