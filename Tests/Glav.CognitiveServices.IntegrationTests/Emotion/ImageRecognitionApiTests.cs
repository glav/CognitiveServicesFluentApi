using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Emotion.Configuration;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.Emotion.Fluent;
using System.Linq;
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
                .WithImageRecognition("https://pixabay.com/en/laugh-child-girl-face-happy-human-536287/")
                .AnalyseAllEmotionsAsync();

            Assert.NotNull(result);
        }


    }
}
 