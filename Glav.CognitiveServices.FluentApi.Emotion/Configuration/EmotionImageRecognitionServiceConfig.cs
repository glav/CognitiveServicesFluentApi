using System;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Emotion.Configuration
{
    public class EmotionImageRecognitionServiceConfig : ApiServiceUriFragment
    {

        public override ApiActionCategory ApiCategory => ApiActionCategory.Emotion;

        public override string Template => "emotion/{0}/recognize";

        public override string Version => ApiConstants.EMOTION_VERSION;
    }
}
