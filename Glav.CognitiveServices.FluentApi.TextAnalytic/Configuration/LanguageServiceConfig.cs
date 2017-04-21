using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class LanguageServiceConfig : BaseApiServiceUriFragment
    {
        public LanguageServiceConfig()
        {
            Version = ApiConstants.TEXT_ANALYTIC_VERSION;
            Template = "text/analytics/{0}/languages";
        }

    }
}
