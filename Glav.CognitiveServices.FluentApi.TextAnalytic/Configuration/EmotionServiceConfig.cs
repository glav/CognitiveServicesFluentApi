using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class EmotionServiceConfig : BaseApiServiceUriFragment
    {
        public EmotionServiceConfig()
        {
            Version = "v2.0";
            Template = "emotion/{0}";
        }

    }
}
