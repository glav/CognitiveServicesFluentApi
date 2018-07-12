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
            _recognizeTextAnalysisResponse = _testHelper.GetFileDataEmbeddedInAssembly("ComputerVisionImageAnalysisResponse.json");
        }

        [Fact]
        public void InitialCallShouldReturnOperationStatusResult()
        {
            var result = new RecognizeTextAnalysisResult(new MockCommsResult(HttpStatusCode.Accepted, "https://cognitiveservice/vision/v2.0/textOperations/49a36324-fc4b-4387-aa06-090cfbf0064f"));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ApiCallResult.OperationLocationUri);


        }
    }
}
