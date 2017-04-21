using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Emotion.Configuration
{
    public class EmotionServiceConfig : BaseApiServiceUriFragment
    {

        public EmotionServiceConfig()
        {
            Version = ApiConstants.EMOTION_VERSION;
            Template = "emotion/{0}";
        }

    }
}
