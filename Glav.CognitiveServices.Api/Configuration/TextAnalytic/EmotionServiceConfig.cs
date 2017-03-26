namespace Glav.CognitiveServices.Api.Configuration.TextAnalytic
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
