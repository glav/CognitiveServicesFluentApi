using Glav.CognitiveServices.Api.Configuration;

namespace Glav.CognitiveServices.Api.Configuration.TextAnalytic
{
    public class TopicServiceConfig : BaseApiServiceUriFragment
    {
        public TopicServiceConfig()
        {
            Version = TEXT_ANALYTIC_VERSION;
            Template = "text/analytics/{0}/topics";
        }

    }
}
