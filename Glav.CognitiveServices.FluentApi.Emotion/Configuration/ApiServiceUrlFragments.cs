using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.Emotion.Configuration
{
    public class ApiServiceUrlFragments : ApiServiceUrlFragmentsBase
    {
        public ApiServiceUrlFragments()
        {
            Services.Add(ApiActionType.Emotion, new EmotionImageRecognitionServiceConfig());
        }
    }
}
