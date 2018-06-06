using Xunit;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;
using System.Linq;
using Glav.CognitiveServices.FluentApi.ComputerVision;
using Glav.CognitiveServices.FluentApi.Core;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class ImageAnalysisParsingTests
    {
        private readonly TestDataHelper _testHelper = new TestDataHelper();
        private readonly string _visionImageAnalysisResponse;

        public ImageAnalysisParsingTests()
        {
            _visionImageAnalysisResponse = _testHelper.GetFileDataEmbeddedInAssembly("ComputerVisionImageAnalysisResponse.json");
        }

        [Fact]
        public void ImageAnalysisResultDataShouldParseSuccessfully()
        {
            var result = new ImageAnalysisResult(new MockCommsResult(_visionImageAnalysisResponse));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.Equal("0dbec5ad-a3d3-4f7e-96b4-dfd57efe967d",result.ResponseData.requestId);

            // Face rectabgle dimensions
            Assert.NotEmpty(result.ResponseData.faces);
            Assert.Equal(1, result.ResponseData.faces.Length);
            Assert.NotNull(result.ResponseData.faces[0].faceRectangle);
            Assert.Equal(44, result.ResponseData.faces[0].age);
            Assert.Equal("Male", result.ResponseData.faces[0].gender);
            Assert.Equal(593, result.ResponseData.faces[0].faceRectangle.left);
            Assert.Equal(160, result.ResponseData.faces[0].faceRectangle.top);
            Assert.Equal(250, result.ResponseData.faces[0].faceRectangle.width);
            Assert.Equal(250, result.ResponseData.faces[0].faceRectangle.height);

            // Find Satya and assert the hell out of him
            Assert.NotNull(result.ResponseData.categories);
            Assert.Equal(2, result.ResponseData.categories.Length);

            var peopleCategory = result.ResponseData.categories.FirstOrDefault(s => s.name == "people_");
            Assert.NotNull(peopleCategory);
            Assert.Equal(0.83984375, peopleCategory.score);
            Assert.NotNull(peopleCategory.detail);
            Assert.NotNull(peopleCategory.detail.celebrities);
            var satya = peopleCategory.detail.celebrities.FirstOrDefault(s => s.name == "Satya Nadella");
            Assert.NotNull(satya);
            Assert.Equal(0.999028444, satya.confidence);

            // Assert the landmark
            Assert.NotNull(peopleCategory.detail.landmarks);
            var forbiddenCity = peopleCategory.detail.landmarks.FirstOrDefault(s => s.name == "Forbidden City");
            Assert.NotNull(forbiddenCity);
            Assert.Equal(0.9978346, forbiddenCity.confidence);

            // Now onto the adult stuff where the real fun is :-)
            Assert.NotNull(result.ResponseData.adult);
            Assert.False(result.ResponseData.adult.isAdultContent);
            Assert.False(result.ResponseData.adult.isRacyContent);
            Assert.Equal(0.0934349000453949, result.ResponseData.adult.adultScore);
            Assert.Equal(0.068613491952419281, result.ResponseData.adult.racyScore);

            // Tags - getting bored now
            Assert.NotNull(result.ResponseData.tags);
            Assert.Equal(4, result.ResponseData.tags.Length);

            // Metadata - yawn'
            Assert.NotNull(result.ResponseData.metadata);
            Assert.Equal(1500, result.ResponseData.metadata.width);
            Assert.Equal(1000, result.ResponseData.metadata.height);
            Assert.Equal("Jpeg", result.ResponseData.metadata.format);

            // Colour - almost there
            Assert.NotNull(result.ResponseData.color);
            Assert.Equal("Brown", result.ResponseData.color.dominantColorBackground);
            Assert.Equal("Brown", result.ResponseData.color.dominantColorForeground);
            Assert.False(result.ResponseData.color.isBWImg);
            Assert.Equal("873B59", result.ResponseData.color.accentColor);

            // image type - and done
            Assert.NotNull(result.ResponseData.imageType);
            Assert.Equal(0, result.ResponseData.imageType.clipArtType);
            Assert.Equal(0, result.ResponseData.imageType.lineDrawingType);
        }

        [Fact]
        public async Task ShouldRetrieveDescriptiveCaptionsSucessfully()
        {
            var commsResult = new MockCommsResult(_visionImageAnalysisResponse);
            var commsEngine = new MockCommsEngine(commsResult);
            const string expected = "Satya Nadella sitting on a bench";

            var analysisResult = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("123", FluentApi.Core.LocationKeyIdentifier.AustraliaEast)
                .UsingCustomCommunication(commsEngine)
                .WithComputerVisionAnalysisActions()
                .AddUrlForImageAnalysis("http://someurl/that/wont/get/called")
                .AnalyseAllAsync();

            var result = analysisResult.ImageAnalysis.GetDescriptiveCaptions(0.1);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(1, result.Length);
            Assert.Equal(expected, result[0]);

        }

        [Fact]
        public async Task ShouldRetrieveTagsSuccessfullyOfParticularScoreLevel()
        {
            var commsResult = new MockCommsResult(_visionImageAnalysisResponse);
            var commsEngine = new MockCommsEngine(commsResult);

            var analysisResult = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("123", FluentApi.Core.LocationKeyIdentifier.AustraliaEast)
                .UsingCustomCommunication(commsEngine)
                .WithComputerVisionAnalysisActions()
                .AddUrlForImageAnalysis("http://someurl/that/wont/get/called")
                .AnalyseAllAsync();

            var result = analysisResult.ImageAnalysis.GetTags(DefaultScoreLevels.Positive);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(4, result.Length);

        }

        [Fact]
        public async Task ShouldRetrieveTagsSuccessfullyAboveAParticularScoreLevel()
        {
            var commsResult = new MockCommsResult(_visionImageAnalysisResponse);
            var commsEngine = new MockCommsEngine(commsResult);

            var analysisResult = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("123", FluentApi.Core.LocationKeyIdentifier.AustraliaEast)
                .UsingCustomCommunication(commsEngine)
                .WithComputerVisionAnalysisActions()
                .AddUrlForImageAnalysis("http://someurl/that/wont/get/called")
                .AnalyseAllAsync();

            var result = analysisResult.ImageAnalysis.GetTagsEqualToOrAboveAConfidenceLevel(DefaultScoreLevels.SlightlyPositive);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(4, result.Length);

        }
    }
}
