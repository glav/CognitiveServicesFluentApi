using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.ComputerVision;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Glav.CognitiveServices.IntegrationTests.Helpers;

namespace Glav.CognitiveServices.IntegrationTests.ComputerVision
{
    public class ImageAnalysisApiTests
    {
        private readonly  TestDataHelper _testDataHelper = new TestDataHelper();
        [Fact]
        public async Task FaceDataShouldBeProvidedWhenRequestedAsPartOfAnalysis()
        {
            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.ComputerVisionApiKey, LocationKeyIdentifier.SouthEastAsia)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithComputerVisionAnalysisActions()
                .AddUrlForImageAnalysis("http://www.scface.org/examples/001_frontal.jpg", ImageAnalysisVisualFeatures.Faces)  // or http://recognitionmemory.org/files/2016/04/C2_032.jpg
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
                .AddUrlForImageAnalysis("http://www.scface.org/examples/001_frontal.jpg", ImageAnalysisVisualFeatures.Adult | ImageAnalysisVisualFeatures.Tags
                                        , ImageAnalysisDetails.Celebrities, SupportedLanguageType.English)
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

        [Fact]
        public async Task ShouldSupportMultipleImagesForAnalysis()
        {
            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.ComputerVisionApiKey, LocationKeyIdentifier.SouthEastAsia)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithComputerVisionAnalysisActions()
                .AddUrlForImageAnalysis("http://www.scface.org/examples/001_frontal.jpg", ImageAnalysisVisualFeatures.Tags | ImageAnalysisVisualFeatures.Categories
                                        , ImageAnalysisDetails.Celebrities, SupportedLanguageType.English)
                .AddUrlForImageAnalysis("http://recognitionmemory.org/files/2016/04/C2_032.jpg", ImageAnalysisVisualFeatures.Categories)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.ImageAnalysis);
            Assert.NotNull(result.ImageAnalysis.AnalysisResults);
            Assert.Equal(2, result.ImageAnalysis.AnalysisResults.Count);

            Assert.True(result.ImageAnalysis.AnalysisResults.All(r => r.ApiCallResult != null));
            Assert.True(result.ImageAnalysis.AnalysisResults.All(r => r.ResponseData != null));
            Assert.True(result.ImageAnalysis.AnalysisResults.All(r => r.ActionSubmittedSuccessfully));

            var firstResult = result.ImageAnalysis.AnalysisResult;
            Assert.NotNull(firstResult.ResponseData.tags);

            Assert.NotNull(firstResult.ResponseData.categories);
            Assert.NotNull(firstResult.ResponseData.categories.First());
            Assert.NotNull(firstResult.ResponseData.categories.First().detail);
            Assert.NotNull(firstResult.ResponseData.categories.First().detail.celebrities);

            var secondResult = result.ImageAnalysis.AnalysisResults[1];
            Assert.NotNull(secondResult.ResponseData.categories);
        }

        [Fact]
        public async Task ShouldBeAbleToAnalyseImageFromBinaryData()
        {
            var fileData = _testDataHelper.GetFileDataEmbeddedInAssembly("yeti-car.jpg");

            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.ComputerVisionApiKey, LocationKeyIdentifier.SouthEastAsia)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithComputerVisionAnalysisActions()
                .AddFileForImageAnalysis(fileData, ImageAnalysisVisualFeatures.Tags)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.ImageAnalysis);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult);
            Assert.True(result.ImageAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult.ResponseData);
            Assert.NotNull(result.ImageAnalysis.AnalysisResult.ResponseData.tags);
        }

        [Fact]
        public async Task ShouldBeAbleToAnalyseImageFromBinaryDataAndFromUrlInTheSamePipeline()
        {
            var fileData = _testDataHelper.GetFileDataEmbeddedInAssembly("yeti-car.jpg");

            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.ComputerVisionApiKey, LocationKeyIdentifier.SouthEastAsia)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithComputerVisionAnalysisActions()
                .AddFileForImageAnalysis(fileData, ImageAnalysisVisualFeatures.Tags)
                .AddUrlForImageAnalysis("http://www.scface.org/examples/001_frontal.jpg",ImageAnalysisVisualFeatures.Faces)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.ImageAnalysis);
            Assert.NotNull(result.ImageAnalysis.AnalysisResults);
            Assert.Equal(2, result.ImageAnalysis.AnalysisResults.Count);
            result.ImageAnalysis.AnalysisResults.ForEach(r =>
            {
                Assert.NotNull(r.ResponseData);
                Assert.True(r.ActionSubmittedSuccessfully);
            });

            // Our first image analysis only requested tags so we check we have some
            Assert.NotNull(result.ImageAnalysis.AnalysisResults[0].ResponseData.tags);
            Assert.NotEmpty(result.ImageAnalysis.AnalysisResults[0].ResponseData.tags);

            // Our second image anlysis only requested faces so we check we have some
            Assert.NotNull(result.ImageAnalysis.AnalysisResults[1].ResponseData.faces);
            Assert.NotEmpty(result.ImageAnalysis.AnalysisResults[1].ResponseData.faces);
        }

    }
}
