using Glav.CognitiveServices.Api.Configuration;

namespace Glav.CognitiveServices.Api.Configuration.TextAnalytic
{
    public class SentimentServiceConfig : BaseApiServiceUriFragment
    {
        public SentimentServiceConfig()
        {
            Version = TEXT_ANALYTIC_VERSION;
            Template = "text/analytics/{0}/sentiment";
        }

    }
}
