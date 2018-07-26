using Glav.CognitiveServices.FluentApi.ComputerVision;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.IntegrationTests.Helpers;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.ComputerVision
{
    public class RecognizeTextAnalysisApiTests
    {
        private TestDataHelper _testDataHelper = new TestDataHelper();

        [Fact]
        public async Task HandwritingTextSHouldBeRecognised()
        {
            var imageData = _testDataHelper.GetFileDataEmbeddedInAssembly("Handwriting1.png");
            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.ComputerVisionApiKey, LocationKeyIdentifier.SouthEastAsia)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithComputerVisionAnalysisActions()
                .AddFileForRecognizeTextAnalysis(imageData,FluentApi.ComputerVision.Domain.RecognizeTextMode.Handwritten)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.RecognizeTextAnalysis);
            Assert.NotNull(result.RecognizeTextAnalysis.AnalysisResult);
            Assert.NotNull(result.RecognizeTextAnalysis.AnalysisResult.ApiCallResult);
            Assert.NotNull(result.RecognizeTextAnalysis.AnalysisResult.ApiCallResult.OperationLocationUri);
            Assert.Equal(HttpStatusCode.Accepted,result.RecognizeTextAnalysis.AnalysisResult.ApiCallResult.StatusCode);

            var analysisResult = await result.WaitForOperationToCompleteAsync();
            Assert.NotNull(analysisResult);
            Assert.Equal(1, analysisResult.Count());
            var firstResult = analysisResult.First();
            Assert.NotNull(firstResult.ResponseData);
            Assert.NotNull(firstResult.ResponseData.recognitionResult);

            Assert.NotNull(firstResult.ResponseData.recognitionResult.lines);
            Assert.NotNull(firstResult.ResponseData.recognitionResult.lines[0].words);
            Assert.Equal("test", firstResult.ResponseData.recognitionResult.lines[0].text);
            Assert.Equal("test", firstResult.ResponseData.recognitionResult.lines[0].words[0].text);

            Assert.Equal(1, firstResult.GetAllRecognisedText().Count());
            Assert.Equal("test", firstResult.GetAllRecognisedText().First());


        }
    }
}
