using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Emotion.Configuration
{
    public class EmotionImageRecognitionServiceConfig : BaseApiServiceUriFragment
    {

        public EmotionImageRecognitionServiceConfig()
        {
            Version = ApiConstants.EMOTION_VERSION;
            Template = "emotion/{0}/recognize";
        }

    }
}
