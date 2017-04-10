using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class OperationStatusServiceConfig : BaseApiServiceUriFragment
    {
        public OperationStatusServiceConfig()
        {
            Version = TEXT_ANALYTIC_VERSION;
            Template = "text/analytics/{0}/operations";
        }

    }
}
