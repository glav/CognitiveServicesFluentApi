using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class EmotionServiceConfig : BaseApiServiceUriFragment
    {
        public EmotionServiceConfig()
        {
            Version = TEXT_ANALYTIC_VERSION;
            Template = "emotion/{0}";
        }

    }
}
