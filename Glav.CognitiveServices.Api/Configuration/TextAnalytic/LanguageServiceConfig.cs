using Glav.CognitiveServices.Api.Configuration;

namespace Glav.CognitiveServices.Api.Configuration.TextAnalytic
{
    public class LanguageServiceConfig : BaseApiServiceUriFragment
    {
        public LanguageServiceConfig()
        {
            Version = TEXT_ANALYTIC_VERSION;
            Template = "text/analytics/{0}/languages";
        }

    }
}
