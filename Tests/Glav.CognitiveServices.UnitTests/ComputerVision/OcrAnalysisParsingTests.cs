using Xunit;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.ComputerVision;
using System.Linq;

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

            var line1 = result.ResponseData.regions[0].lines[0];
            Assert.Equal("A", line1.words[0].text);
            Assert.Equal("462,379,41,73", line1.words[0].boundingBox);
            Assert.Equal("GOAL", line1.words[1].text);
            Assert.Equal("523,379,153,73", line1.words[1].boundingBox);
            Assert.Equal("WITHOUT", line1.words[2].text);
            Assert.Equal("694,379,265,74", line1.words[2].boundingBox);

            var line2 = result.ResponseData.regions[0].lines[1];
            Assert.Equal("A", line2.words[0].text);
            Assert.Equal("565,471,41,73", line2.words[0].boundingBox);
            Assert.Equal("PLAN", line2.words[1].text);
            Assert.Equal("626,471,150,73", line2.words[1].boundingBox);
            Assert.Equal("IS", line2.words[2].text);
            Assert.Equal("801,472,53,73", line2.words[2].boundingBox);

            var line3 = result.ResponseData.regions[0].lines[2];
            Assert.Equal("JUST", line3.words[0].text);
            Assert.Equal("519,563,149,74", line3.words[0].boundingBox);
            Assert.Equal("A", line3.words[1].text);
            Assert.Equal("683,564,41,72", line3.words[1].boundingBox);
            Assert.Equal("WISH", line3.words[2].text);
            Assert.Equal("741,564,153,73", line3.words[2].boundingBox);

        }

        [Fact]
        public async Task ExtensionMethodCanReturnJustAllWords()
        {
            var expected = new string[] { "A", "GOAL", "WITHOUT", "A", "PLAN", "IS", "JUST", "A", "WISH" };
            var mockCommsEngine = new MockCommsEngine(new MockCommsResult(_visionOcrAnalysisResponse));
            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.SouthEastAsia)
                .UsingCustomCommunication(mockCommsEngine)
                .WithComputerVisionAnalysisActions()
                .AddUrlForOcrAnalysis("http://thegovernment.com/your_mum.jpg", false)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.OcrAnalysis);
            var words = result.OcrAnalysis.GetAllWords();

            Assert.Equal(9, words.Count());
            for (var wordCnt=0; wordCnt < words.Count(); wordCnt++)
            {
                Assert.Equal(expected[wordCnt], words.ElementAt(wordCnt));
            }
        }

        [Fact]
        public async Task ExtensionMethodReturnsStronglyTypedOrientation()
        {
            var mockCommsEngine = new MockCommsEngine(new MockCommsResult(_visionOcrAnalysisResponse));
            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.SouthEastAsia)
                .UsingCustomCommunication(mockCommsEngine)
                .WithComputerVisionAnalysisActions()
                .AddUrlForOcrAnalysis("http://thegovernment.com/lochness_monster.jpg", false)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.OcrAnalysis);
            Assert.NotNull(result.OcrAnalysis.AnalysisResult);

            Assert.Equal(OcrTextOrientation.Up, result.OcrAnalysis.AnalysisResult.GetOrientation());
        }

        [Fact]
        public async Task ExtensionMethodCanReturnBoundingBoxForItem()
        {
            var expected = new string[] { "A", "GOAL", "WITHOUT", "A", "PLAN", "IS", "JUST", "A", "WISH" };
            var mockCommsEngine = new MockCommsEngine(new MockCommsResult(_visionOcrAnalysisResponse));
            var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.SouthEastAsia)
                .UsingCustomCommunication(mockCommsEngine)
                .WithComputerVisionAnalysisActions()
                .AddUrlForOcrAnalysis("http://thegovernment.com/your_loungeroom.jpg", false)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            result.OcrAnalysis.AssertAnalysisContextValidity();
            Assert.NotNull(result.OcrAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.OcrAnalysis.AnalysisResult.ResponseData.regions);

            var regionResult = result.OcrAnalysis.AnalysisResult.ResponseData.regions[0];

            var regionBoundingBox = regionResult.GetBoundingBoxCoordinates();
            Assert.Equal(462, regionBoundingBox.XTopLeft);
            Assert.Equal(379, regionBoundingBox.YTopLeft);
            Assert.Equal(497, regionBoundingBox.Width);
            Assert.Equal(258, regionBoundingBox.Height);


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
            string[] inputs = new[] { "x,379,,258", "", "   ", "whatevs" };
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

        [Fact]
        public void LanguageParsingShouldReturnCorrectResult()
        {
            var allLangs = LanguageListBuilder.GetAllSupportedLanguages();
            foreach (var lang in allLangs)
            {
                Assert.Equal(lang.LanguageType, LanguageCodeParser.Parse(lang.Code).LanguageType);
            }
        }

    }
}
