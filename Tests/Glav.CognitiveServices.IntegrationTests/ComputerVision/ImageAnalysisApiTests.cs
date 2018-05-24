using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.ComputerVision;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace Glav.CognitiveServices.IntegrationTests.ComputerVision
{
    public class ImageAnalysisApiTests
    {
        [Fact]
        public async Task FaceDataShouldBeProvidedWhenRequestedAsPartOfAnalysis()
        {
            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.ComputerVisionApiKey, LocationKeyIdentifier.SouthEastAsia)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithComputerVisionAnalysisActions()
                .AddImageAnalysis("http://www.scface.org/examples/001_frontal.jpg",ImageAnalysisVisualFeatures.Faces)  // or http://recognitionmemory.org/files/2016/04/C2_032.jpg
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.ImageAnalysis);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult.ApiCallResult);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult.ResponseData);
            Assert.True(result.ImageAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotEmpty(result.ImageAnalysis.AnalysisResult.ResponseData.faces);
        }

        [Fact]
        public async Task AdultTagAndCelebrityDataDataShouldBeProvidedWhenRequestedAsPartOfAnalysis()
        {
            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.ComputerVisionApiKey, LocationKeyIdentifier.SouthEastAsia)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithComputerVisionAnalysisActions()
                .AddImageAnalysis("http://www.scface.org/examples/001_frontal.jpg", ImageAnalysisVisualFeatures.Adult | ImageAnalysisVisualFeatures.Tags
                                        ,ImageAnalysisDetails.Celebrities,SupportedLanguageType.English)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.ImageAnalysis);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult.ApiCallResult);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult.ResponseData);
            Assert.True(result.ImageAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult.ResponseData.adult);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult.ResponseData.tags);
            Assert.NotEmpty(result.ImageAnalysis.AnalysisResult.ResponseData.tags);
        }

        //[Fact]
        public async Task ShouldSupportMultipleImagesForAnalysis()
        {
            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.ComputerVisionApiKey, LocationKeyIdentifier.SouthEastAsia)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithComputerVisionAnalysisActions()
                .AddImageAnalysis("http://www.scface.org/examples/001_frontal.jpg", ImageAnalysisVisualFeatures.Tags
                                        , ImageAnalysisDetails.Celebrities, SupportedLanguageType.English)
                .AddImageAnalysis("http://recognitionmemory.org/files/2016/04/C2_032.jpg",ImageAnalysisVisualFeatures.Categories)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.ImageAnalysis);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult.ApiCallResult);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult.ResponseData);
            Assert.True(result.ImageAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult.ResponseData.adult);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult.ResponseData.tags);
            Assert.NotEmpty(result.ImageAnalysis.AnalysisResult.ResponseData.tags);
        }


    }
}
 