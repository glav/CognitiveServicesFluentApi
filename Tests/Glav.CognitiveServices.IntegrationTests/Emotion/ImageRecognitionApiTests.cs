using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Emotion;
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
                //.WithImageRecognition("http://www.cse.oulu.fi/wsgi/CMV/Downloads/Pbfd?action=AttachFile&do=get&target=hh.jpg")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.ImageRecognitionAnalysis);
            Assert.NotNull(result.ImageRecognitionAnalysis.AnalysisResult);
            Assert.NotNull(result.ImageRecognitionAnalysis.AnalysisResult.ApiCallResult);
            Assert.NotNull(result.ImageRecognitionAnalysis.AnalysisResult.ResponseData);
            Assert.True(result.ImageRecognitionAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotEmpty(result.ImageRecognitionAnalysis.AnalysisResult.ResponseData.faces);
        }


    }
}
 