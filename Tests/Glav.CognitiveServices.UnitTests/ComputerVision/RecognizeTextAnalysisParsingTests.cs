using Xunit;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;
using System.Linq;
using Glav.CognitiveServices.FluentApi.ComputerVision;
using Glav.CognitiveServices.FluentApi.Core;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.Core.Operations;
using System.Net;

namespace Glav.CognitiveServices.UnitTests.ComputerVision
{
    public class RecognizeTextAnalysisParsingTests
    {
        private readonly TestDataHelper _testHelper = new TestDataHelper();
        private readonly string _recognizeTextAnalysisResponse;

        public RecognizeTextAnalysisParsingTests()
        {
            _recognizeTextAnalysisResponse = _testHelper.GetFileDataEmbeddedInAssembly("ComputerVisionRecognizeTextAnalysisResponse.json");
        }

        [Fact]
        public void InitialCallShouldReturnOperationStatusResult()
        {
            int[] expeectedLineBoundingBox =  new int[] { 283, 130, 299, 50, 315, 53, 299, 133 };
            var result = new RecognizeTextAnalysisResult(new MockCommsResult(_recognizeTextAnalysisResponse));

            Assert.NotNull(result);
            Assert.NotNull(result.ResponseData);
            Assert.NotNull(result.ResponseData.recognitionResult);
            Assert.NotEmpty(result.ResponseData.recognitionResult.lines);
            Assert.Equal(1,result.ResponseData.recognitionResult.lines.Length);
            Assert.Equal("test", result.ResponseData.recognitionResult.lines[0].text);
            Assert.NotEmpty(result.ResponseData.recognitionResult.lines[0].boundingBox);
            Assert.NotEmpty(result.ResponseData.recognitionResult.lines[0].words);
            Assert.Equal(1, result.ResponseData.recognitionResult.lines[0].words.Length);

            for (var cnt=0; cnt < expeectedLineBoundingBox.Length; cnt++)
            {
                Assert.Equal(expeectedLineBoundingBox[cnt],result.ResponseData.recognitionResult.lines[0].boundingBox[cnt]);
            }





        }
    }
}
