using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Emotion.Configuration
{
    public class EmotionServiceConfig : BaseApiServiceUriFragment
    {
        public const string EMOTION_VERSION = "v2.0";

        public EmotionServiceConfig()
        {
            Version = EMOTION_VERSION;
            Template = "emotion/{0}";
        }

    }
}
