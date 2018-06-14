using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.ComputerVision;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Glav.CognitiveServices.IntegrationTests.Helpers;

namespace Glav.CognitiveServices.IntegrationTests.ComputerVision
{
    public class OcrAnalysisApiTests
    {
        private TestDataHelper _testDataHelper = new TestDataHelper();
        [Fact]
        public async Task TextInPhotohHouldBeRecognised_Mostly()
        {
            var imageData = _testDataHelper.GetFileDataEmbeddedInAssembly("abbey_road.png");
            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.ComputerVisionApiKey, LocationKeyIdentifier.SouthEastAsia)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithComputerVisionAnalysisActions()
                .AddFileForImageAnalysis(imageData, false)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.OcrAnalysis);
            Assert.NotNull(result.OcrAnalysis.AnalysisResult);
            Assert.NotNull(result.OcrAnalysis.AnalysisResult.ApiCallResult);
            Assert.NotNull(result.OcrAnalysis.AnalysisResult.ResponseData);
            Assert.True(result.OcrAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotEmpty(result.OcrAnalysis.AnalysisResult.ResponseData.regions);
            Assert.Equal(1, result.OcrAnalysis.AnalysisResult.ResponseData.regions.Length);
            Assert.Equal(3, result.OcrAnalysis.AnalysisResult.ResponseData.regions[0].lines.Length);

            var line1 = result.OcrAnalysis.AnalysisResult.ResponseData.regions[0].lines[0];
            var line2 = result.OcrAnalysis.AnalysisResult.ResponseData.regions[0].lines[1];
            var line3 = result.OcrAnalysis.AnalysisResult.ResponseData.regions[0].lines[2];
            Assert.Equal(1, line1.words.Length);
            Assert.Equal(2, line2.words.Length);
            Assert.Equal(2, line3.words.Length);

            Assert.Equal("ABBEY", line1.words[0].text);

            // Note: Not asserting the rest of the words in the image as the API does not correctly recognise them :-)
            // This image was taken from google
        }

        [Fact]
        public async Task PrintedTextInImageSHouldBeRecognised()
        {
            var imageData = _testDataHelper.GetFileDataEmbeddedInAssembly("printed-text.JPG");
            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.ComputerVisionApiKey, LocationKeyIdentifier.SouthEastAsia)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithComputerVisionAnalysisActions()
                .AddFileForImageAnalysis(imageData, false)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.OcrAnalysis);
            Assert.NotNull(result.OcrAnalysis.AnalysisResult);
            Assert.NotNull(result.OcrAnalysis.AnalysisResult.ApiCallResult);
            Assert.NotNull(result.OcrAnalysis.AnalysisResult.ResponseData);
            Assert.True(result.OcrAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotEmpty(result.OcrAnalysis.AnalysisResult.ResponseData.regions);
            Assert.Equal(1, result.OcrAnalysis.AnalysisResult.ResponseData.regions.Length);
            Assert.Equal(4, result.OcrAnalysis.AnalysisResult.ResponseData.regions[0].lines.Length);

            var line1 = result.OcrAnalysis.AnalysisResult.ResponseData.regions[0].lines[0];
            var line2 = result.OcrAnalysis.AnalysisResult.ResponseData.regions[0].lines[1];
            var line3 = result.OcrAnalysis.AnalysisResult.ResponseData.regions[0].lines[2];
            var line4 = result.OcrAnalysis.AnalysisResult.ResponseData.regions[0].lines[3];
            Assert.Equal(1, line1.words.Length);
            Assert.Equal(1, line2.words.Length);
            Assert.Equal(1, line3.words.Length);
            Assert.Equal(1, line4.words.Length);

            // So because this image is printed text, OCR works much better and it recognises all the words
            Assert.Equal("ESTA67", line1.words[0].text);
            Assert.Equal("ES767", line2.words[0].text);
            Assert.Equal("UNA4567", line3.words[0].text);
            Assert.Equal("PRUEBA5887", line4.words[0].text);

            Assert.Equal("24,29,186,38", line1.words[0].boundingBox);
            Assert.Equal("24,88,148,38", line2.words[0].boundingBox);
            Assert.Equal("24,148,218,38", line3.words[0].boundingBox);
            Assert.Equal("24,208,324,37", line4.words[0].boundingBox);

            // Note: Not asserting the rest of the words in the image as the API does not correctly recognise them :-)
            // This image was taken from google
        }



    }
}
