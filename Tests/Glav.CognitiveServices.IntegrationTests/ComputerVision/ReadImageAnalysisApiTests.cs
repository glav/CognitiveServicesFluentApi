using Glav.CognitiveServices.FluentApi.ComputerVision;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.IntegrationTests.Helpers;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.ComputerVision
{
    public class ReadImageAnalysisApiTests
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
                .AddFileForReadImageAnalysis(imageData,SupportedLanguageType.English)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.ReadImageAnalysis);
            Assert.NotNull(result.ReadImageAnalysis.AnalysisResult);
            Assert.NotNull(result.ReadImageAnalysis.AnalysisResult.ApiCallResult);
            Assert.NotNull(result.ReadImageAnalysis.AnalysisResult.ApiCallResult.OperationLocationUri);
            Assert.Equal(HttpStatusCode.Accepted,result.ReadImageAnalysis.AnalysisResult.ApiCallResult.StatusCode);

            var analysisResult = await result.WaitForOperationToCompleteAsync();
            Assert.NotNull(analysisResult);
            Assert.Equal(1, analysisResult.Count());
            var firstResult = analysisResult.First();
            Assert.NotNull(firstResult.ResponseData);
            Assert.NotNull(firstResult.ResponseData.analyzeResult);

            Assert.NotNull(firstResult.ResponseData.analyzeResult.readResults);
            Assert.NotNull(firstResult.ResponseData.analyzeResult.readResults[0].lines);
            Assert.Equal(1, firstResult.ResponseData.analyzeResult.readResults[0].lines.Length);
            Assert.Equal("test", firstResult.ResponseData.analyzeResult.readResults[0].lines[0].text);
            Assert.NotNull(firstResult.ResponseData.analyzeResult.readResults[0].lines[0].words);
            Assert.Equal(1, firstResult.ResponseData.analyzeResult.readResults[0].lines[0].words.Length);
            Assert.Equal("test", firstResult.ResponseData.analyzeResult.readResults[0].lines[0].words[0].text);

            Assert.Equal(1, firstResult.GetAllRecognisedText().Count());
            Assert.Equal("test", firstResult.GetAllRecognisedText().First());

            var words = firstResult.GetAllRecognisedWords();
            Assert.Equal(1, words.Count());
            Assert.Equal("test", words.First());
        }
    }
}
