using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Emotion.Configuration;
using Glav.CognitiveServices.FluentApi.Emotion.Fluent;
using System.Threading.Tasks;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.Emotion
{
    public class ImageRecognitionApiTests
    {
        [Fact]
        public async Task SimplePositiveTextShouldAnalyseAsPositive()
        {
            var result = await EmotionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.EmotionApiKey, LocationKeyIdentifier.WestUs)
                .UsingHttpCommunication()
                .WithEmotionAnalysisActions()
                .AddImageRecognition("http://www.scface.org/examples/001_frontal.jpg")
                //.WithImageRecognition("http://www.cse.oulu.fi/wsgi/CMV/Downloads/Pbfd?action=AttachFile&do=get&target=hh.jpg")
                .AnalyseAllEmotionsAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.ImageRecognitionAnalysis);
            Assert.NotNull(result.ImageRecognitionAnalysis.AnalysisResult);
            Assert.NotNull(result.ImageRecognitionAnalysis.AnalysisResult.ApiCallResult);
            Assert.NotNull(result.ImageRecognitionAnalysis.AnalysisResult.ResponseData);
            Assert.True(result.ImageRecognitionAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotEmpty(result.ImageRecognitionAnalysis.AnalysisResult.ResponseData.faces);
        }


    }
}
 