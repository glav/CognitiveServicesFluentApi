using Xunit;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.UnitTests.ComputerVision
{
    public class OcrAnalysisParsingTests
    {
        private readonly TestDataHelper _testHelper = new TestDataHelper();
        private readonly string _visionOcrAnalysisResponse;

        public OcrAnalysisParsingTests()
        {
            _visionOcrAnalysisResponse = _testHelper.GetFileDataEmbeddedInAssembly("ComputerVisionOcrAnalysisResponse.json");
        }

        [Fact]
        public void OcrAnalysisResultDataShouldParseSuccessfully()
        {
            var result = new OcrAnalysisResult(new MockCommsResult(_visionOcrAnalysisResponse));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.Equal(SupportedLanguageType.English.ToCode(), result.ResponseData.language);
            Assert.Equal(-2.0000000000000338, result.ResponseData.textAngle);
            Assert.Equal(1, result.ResponseData.regions.Length);
            Assert.NotEmpty(result.ResponseData.regions[0].lines);
            Assert.Equal(3, result.ResponseData.regions[0].lines.Length);
            Assert.Equal("462,379,497,74", result.ResponseData.regions[0].lines[0].boundingBox);
            Assert.Equal("565,471,289,74", result.ResponseData.regions[0].lines[1].boundingBox);
            Assert.Equal("519,563,375,74", result.ResponseData.regions[0].lines[2].boundingBox);
            Assert.NotEmpty(result.ResponseData.regions[0].lines[0].words);
            Assert.Equal(3, result.ResponseData.regions[0].lines[0].words.Length);
            Assert.NotEmpty(result.ResponseData.regions[0].lines[1].words);
            Assert.Equal(3, result.ResponseData.regions[0].lines[1].words.Length);
            Assert.NotEmpty(result.ResponseData.regions[0].lines[2].words);
            Assert.Equal(3, result.ResponseData.regions[0].lines[2].words.Length);
            Assert.Equal("A", result.ResponseData.regions[0].lines[0].words[0].text);
            Assert.Equal("462,379,41,73", result.ResponseData.regions[0].lines[0].words[0].boundingBox);
            Assert.Equal("GOAL", result.ResponseData.regions[0].lines[0].words[1].text);
            Assert.Equal("523,379,153,73", result.ResponseData.regions[0].lines[0].words[1].boundingBox);
            Assert.Equal("WITHOUT", result.ResponseData.regions[0].lines[0].words[2].text);
            Assert.Equal("694,379,265,74", result.ResponseData.regions[0].lines[0].words[2].boundingBox);

        }

        [Fact]
        public void BoundingBoxResponseShouldParseIntoCoordinates()
        {
            string[] inputs = new[] { "462,379,497,258", "565,471,289,74" };
            BoundingBoxCoordinates[] expectedResults = new[]
            {
                new BoundingBoxCoordinates { XTopLeft = 462, YTopLeft = 379, Width = 497, Height = 258},
                new BoundingBoxCoordinates { XTopLeft = 565, YTopLeft = 471, Width = 289, Height = 74}
            };

            for (var cnt = 0; cnt < inputs.Length; cnt++)
            {
                var item = inputs[cnt];
                var expected = expectedResults[cnt];
                var test = BoundingBoxCoordinates.Parse(item);
                Assert.Equal(expected.XTopLeft, test.XTopLeft);
                Assert.Equal(expected.YTopLeft, test.YTopLeft);
                Assert.Equal(expected.Width, test.Width);
                Assert.Equal(expected.Height, test.Height);
            }

        }

        [Fact]
        public void BoundingBoxCoordinatesShouldTolerateBadData()
        {
            string[] inputs = new[] { "x,379,,258", "","   ","whatevs" };
            BoundingBoxCoordinates[] expectedResults = new[]
            {
                new BoundingBoxCoordinates{ XTopLeft= 0, YTopLeft= 379, Width=0,Height= 258 },
                new BoundingBoxCoordinates(),
                new BoundingBoxCoordinates(),
                new BoundingBoxCoordinates()
            };

            for (var cnt = 0; cnt < inputs.Length; cnt++)
            {
                var item = inputs[cnt];
                var expected = expectedResults[cnt];
                var test = BoundingBoxCoordinates.Parse(item);
                Assert.Equal(expected.XTopLeft, test.XTopLeft);
                Assert.Equal(expected.YTopLeft, test.YTopLeft);
                Assert.Equal(expected.Width, test.Width);
                Assert.Equal(expected.Height, test.Height);
            }

        }

    }
}
