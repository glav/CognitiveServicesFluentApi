using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Emotion.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection()
        {
            Services.Add(ApiActionType.EmotionImageRecognition, new EmotionImageRecognitionServiceConfig());
        }
    }
}
