using Xunit;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;
using System.Linq;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class ImageAnalysisParsingTests
    {
        private TestDataHelper _testHelper = new TestDataHelper();

        [Fact]
        public void ImageAnalysisResultDataShouldParseSuccessfully()
        {
            var responseFromApi = _testHelper.GetFileDataEmbeddedInAssembly("ComputerVisionImageAnalysisResponse.json");
            var result = new ImageAnalysisResult(new MockCommsResult(responseFromApi));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);

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
        }
    }
}
