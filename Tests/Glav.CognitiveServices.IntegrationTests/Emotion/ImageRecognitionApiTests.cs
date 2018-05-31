using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Emotion;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.ComputerVsion
{
    public class ImageRecognitionApiTests
    {
        [Fact]
        public async Task ShouldDetectFaces()
        {
            var result = await EmotionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.EmotionApiKey, LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithEmotionAnalysisActions()
                .AddImageRecognition("http://www.scface.org/examples/001_frontal.jpg")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.ImageRecognitionAnalysis);
            Assert.NotNull(result.ImageRecognitionAnalysis.AnalysisResult);
            Assert.NotNull(result.ImageRecognitionAnalysis.AnalysisResult.ApiCallResult);
            Assert.NotNull(result.ImageRecognitionAnalysis.AnalysisResult.ResponseData);
            Assert.True(result.ImageRecognitionAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotEmpty(result.ImageRecognitionAnalysis.AnalysisResult.ResponseData.faces);
        }

        [Fact]
        public async Task ShouldSupportMultipleImagesForFacialDetection()
        {
            var result = await EmotionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.EmotionApiKey, LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithEmotionAnalysisActions()
                .AddImageRecognition("http://www.scface.org/examples/001_frontal.jpg")
                .AddImageRecognition("http://www.cse.oulu.fi/wsgi/CMV/Downloads/Pbfd?action=AttachFile&do=get&target=hh.jpg")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.ImageRecognitionAnalysis);
            Assert.NotEmpty(result.ImageRecognitionAnalysis.AnalysisResults);
            Assert.Equal(2, result.ImageRecognitionAnalysis.AnalysisResults.Count);
            Assert.True(result.ImageRecognitionAnalysis.AnalysisResults.All(i => i.ApiCallResult != null));
            Assert.True(result.ImageRecognitionAnalysis.AnalysisResults.All(i => i.ResponseData != null));
            Assert.True(result.ImageRecognitionAnalysis.AnalysisResults.All(i => i.ActionSubmittedSuccessfully));
            Assert.True(result.ImageRecognitionAnalysis.AnalysisResults.All(i => i.ResponseData.faces != null));
            Assert.True(result.ImageRecognitionAnalysis.AnalysisResults.All(i => i.ResponseData.faces.Length > 0));
        }

    }
}
 