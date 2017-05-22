using Xunit;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class EmotionParsingTests
    {
        [Fact]
        public void EmotionFaceDataShouldParseSuccessfully()
        {
            var input = "[  {    \"faceRectangle\": {       \"left\": 68,       \"top\": 97,       \"width\": 64,       \"height\": 97     }" +
                ",     \"scores\": {       \"anger\": 0.00300731952,       \"contempt\": 5.14648448E-08,       \"disgust\": 9.180124E-06," +
                "       \"fear\": 0.0001912825,       \"happiness\": 0.9875571,       \"neutral\": 0.0009861537,       \"sadness\": 1.889955E-05," +
                "       \"surprise\": 0.008229999     }   } ]";
            var result = new ImageRecognitionResult(new MockCommsResult(input));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.NotEmpty(result.ResponseData.faces);
            Assert.Equal(1,result.ResponseData.faces.Length);
            Assert.NotNull(result.ResponseData.faces[0].faceRectangle);
            Assert.NotNull(result.ResponseData.faces[0].scores);

            // Face rectabgle dimensions
            Assert.Equal(68,result.ResponseData.faces[0].faceRectangle.left);
            Assert.Equal(97, result.ResponseData.faces[0].faceRectangle.top);
            Assert.Equal(64, result.ResponseData.faces[0].faceRectangle.width);
            Assert.Equal(97, result.ResponseData.faces[0].faceRectangle.height);

            // Scores
            Assert.Equal(0.00300731952, result.ResponseData.faces[0].scores.anger);
            Assert.Equal(5.14648448E-08, result.ResponseData.faces[0].scores.contempt);
            Assert.Equal(9.180124E-06, result.ResponseData.faces[0].scores.disgust);
            Assert.Equal(0.0001912825, result.ResponseData.faces[0].scores.fear);
            Assert.Equal(0.9875571, result.ResponseData.faces[0].scores.happiness);
            Assert.Equal(0.0009861537, result.ResponseData.faces[0].scores.neutral);
            Assert.Equal(1.889955E-05, result.ResponseData.faces[0].scores.sadness);
            Assert.Equal(0.008229999, result.ResponseData.faces[0].scores.surprise);
        }

        [Fact]
        public void EmotionErrorDataShouldParseSuccessfully()
        {
            // Simulate error response with error data and http code
            var input = "{  \"error\": {    \"code\": \"BadBody\",    \"message\": \"Invalid face image.\"  }    }";
            var result = new ImageRecognitionResult(new MockCommsResult(input,System.Net.HttpStatusCode.BadRequest)); 

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.False(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.NotNull(result.ResponseData.error);

            Assert.Equal("BadBody", result.ResponseData.error.code);
            Assert.Equal("Invalid face image.", result.ResponseData.error.message);
        }
    }
}
