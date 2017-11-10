using Xunit;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class ImageAnalysisParsingTests
    {
        [Fact]
        public void ImageAnalysisResultDataShouldParseSuccessfully()
        {
            var input = ""; //TODO: Get sample response from computer vision site
            var result = new ImageAnalysisResult(new MockCommsResult(input));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.NotEmpty(result.ResponseData.faces);
            Assert.Equal(1, result.ResponseData.faces.Length);
            Assert.NotNull(result.ResponseData.faces[0].faceRectangle);

            // Face rectabgle dimensions
            Assert.Equal(68, result.ResponseData.faces[0].faceRectangle.left);
            Assert.Equal(97, result.ResponseData.faces[0].faceRectangle.top);
            Assert.Equal(64, result.ResponseData.faces[0].faceRectangle.width);
            Assert.Equal(97, result.ResponseData.faces[0].faceRectangle.height);
        }
    }
}
