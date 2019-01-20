using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Glav.CognitiveServices.IntegrationTests.Helpers;
using Glav.CognitiveServices.FluentApi.Face.Domain;

namespace Glav.CognitiveServices.IntegrationTests.ComputerVision
{
    public class FaceDetectionApiTests
    {
        private TestDataHelper _testDataHelper = new TestDataHelper();
        [Fact]
        public async Task FaceDataShouldBeProvidedWhenRequestedAsPartOfAnalysisForUrlAnalysis()
        {
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .AddUrlForFaceDetection("http://www.scface.org/examples/001_frontal.jpg",FaceDetectionAttributes.Gender)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.FaceDetectionAnalysis);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ApiCallResult);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ResponseData);
            Assert.True(result.FaceDetectionAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotEmpty(result.FaceDetectionAnalysis.AnalysisResult.ResponseData.detectedFaces);
            Assert.Equal(1, result.FaceDetectionAnalysis.AnalysisResult.ResponseData.detectedFaces.Length);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ResponseData.detectedFaces[0].faceAttributes);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ResponseData.detectedFaces[0].faceAttributes.gender);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ResponseData.detectedFaces[0].faceId);
        }

        [Fact]
        public async Task FaceDataShouldBeProvidedWhenRequestedAsPartOfAnalysisForImageFileAnalysis()
        {
            var imageData = _testDataHelper.GetFileDataEmbeddedInAssembly("female_face_image.jpeg");
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .AddFileForFaceDetection(imageData, FaceDetectionAttributes.Gender | FaceDetectionAttributes.Age)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.FaceDetectionAnalysis);
            var results = result.FaceDetectionAnalysis.GetResults();
            Assert.NotNull(results);
            Assert.Equal(1, results.Count());
            var firstResult = results.First();
            Assert.NotNull(firstResult.faceAttributes);

            Assert.NotNull(firstResult.faceAttributes.gender);
            Assert.True(firstResult.faceAttributes.age > 0);
            Assert.NotNull(firstResult.faceId);
        }

    }
}
