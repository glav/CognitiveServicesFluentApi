using Xunit;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;

namespace Glav.CognitiveServices.UnitTests.ComputerVision
{
    public class ReadImageAnalysisParsingTests
    {
        private readonly TestDataHelper _testHelper = new TestDataHelper();
        private readonly string _readImageAnalysisResponse;

        public ReadImageAnalysisParsingTests()
        {
            _readImageAnalysisResponse = _testHelper.GetFileDataEmbeddedInAssembly("ComputerVisionReadImageAnalysisResponse.json");
        }

        [Fact]
        public void InitialCallShouldReturnOperationStatusResult()
        {
            int[] expeectedLineBoundingBox =  new int[] { 202, 618, 2047, 643, 2046, 840, 200, 813 };
            var result = new ReadImageAnalysisResult(new MockCommsResult(_readImageAnalysisResponse));

            Assert.NotNull(result);
            Assert.NotNull(result.ResponseData);
            Assert.NotNull(result.ResponseData.analyzeResult);
            Assert.NotEmpty(result.ResponseData.analyzeResult.readResults);
            Assert.Equal(2,result.ResponseData.analyzeResult.readResults.Length);
            Assert.Equal(49.59, result.ResponseData.analyzeResult.readResults[0].angle);
            Assert.Equal(400, result.ResponseData.analyzeResult.readResults[0].height);
            Assert.Equal("en", result.ResponseData.analyzeResult.readResults[0].language);
            Assert.Equal(1, result.ResponseData.analyzeResult.readResults[0].page);
            Assert.Equal("pixel", result.ResponseData.analyzeResult.readResults[0].unit);
            Assert.Equal(600, result.ResponseData.analyzeResult.readResults[0].width);
            Assert.NotEmpty(result.ResponseData.analyzeResult.readResults[0].lines);
            Assert.Equal(3, result.ResponseData.analyzeResult.readResults[0].lines.Length);
            Assert.Equal("Our greatest glory is not", result.ResponseData.analyzeResult.readResults[0].lines[0].text);
            Assert.NotEmpty(result.ResponseData.analyzeResult.readResults[0].lines[0].boundingBox);
            Assert.NotEmpty(result.ResponseData.analyzeResult.readResults[0].lines[0].words);
            Assert.Equal(5,result.ResponseData.analyzeResult.readResults[0].lines[0].words.Length);
            // Ensure we extract all the result words
            Assert.Equal("Our",result.ResponseData.analyzeResult.readResults[0].lines[0].words[0].text);
            Assert.Equal(0.164,result.ResponseData.analyzeResult.readResults[0].lines[0].words[0].confidence);
            Assert.NotEmpty(result.ResponseData.analyzeResult.readResults[0].lines[0].words[0].boundingBox);
            Assert.Equal("greatest", result.ResponseData.analyzeResult.readResults[0].lines[0].words[1].text);
            Assert.Equal(0.164, result.ResponseData.analyzeResult.readResults[0].lines[0].words[1].confidence);
            Assert.NotEmpty(result.ResponseData.analyzeResult.readResults[0].lines[0].words[1].boundingBox);
            Assert.Equal("glory", result.ResponseData.analyzeResult.readResults[0].lines[0].words[2].text);
            Assert.Equal(0.164, result.ResponseData.analyzeResult.readResults[0].lines[0].words[2].confidence);
            Assert.NotEmpty(result.ResponseData.analyzeResult.readResults[0].lines[0].words[2].boundingBox);
            Assert.Equal("is", result.ResponseData.analyzeResult.readResults[0].lines[0].words[3].text);
            Assert.Equal(0.164, result.ResponseData.analyzeResult.readResults[0].lines[0].words[3].confidence);
            Assert.NotEmpty(result.ResponseData.analyzeResult.readResults[0].lines[0].words[3].boundingBox);
            Assert.Equal("not", result.ResponseData.analyzeResult.readResults[0].lines[0].words[4].text);
            Assert.Equal(0.164, result.ResponseData.analyzeResult.readResults[0].lines[0].words[4].confidence);
            Assert.NotEmpty(result.ResponseData.analyzeResult.readResults[0].lines[0].words[4].boundingBox);

            for (var cnt=0; cnt < expeectedLineBoundingBox.Length; cnt++)
            {
                Assert.Equal(expeectedLineBoundingBox[cnt],result.ResponseData.analyzeResult.readResults[0].lines[0].boundingBox[cnt]);
            }
        }
    }
}
