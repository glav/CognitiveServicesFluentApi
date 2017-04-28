using Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent;
using Xunit;
using System.Reflection;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class EmotionParsingTests
    {
        [Fact]
        public void ShouldParseResultSuccessfully()
        {
            var input = "[  {    \"faceRectangle\": {       \"left\": 68,       \"top\": 97,       \"width\": 64,       \"height\": 97     }" +
                ",     \"scores\": {       \"anger\": 0.00300731952,       \"contempt\": 5.14648448E-08,       \"disgust\": 9.180124E-06," +
                "       \"fear\": 0.0001912825,       \"happiness\": 0.9875571,       \"neutral\": 0.0009861537,       \"sadness\": 1.889955E-05," +
                "       \"surprise\": 0.008229999     }   } ]";
            var result = new EmotionImageRecognitionResult(new MockCommsResult(input));

            //Assert.NotNull(result);
            //Assert.NotNull(result.ApiCallResult);
            //Assert.True(result.ActionSubmittedSuccessfully);
            //Assert.NotNull(result.ResponseData);
            //Assert.NotEmpty(result.ResponseData.documents);
            //Assert.Equal<long>(1, result.ResponseData.documents[0].id);
            //Assert.Equal<double>(0.7988085, result.ResponseData.documents[0].score);
            //Assert.Empty(result.ResponseData.errors);
        }

    }
}
