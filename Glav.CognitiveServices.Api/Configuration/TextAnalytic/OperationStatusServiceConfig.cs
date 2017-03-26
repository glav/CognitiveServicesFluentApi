using Glav.CognitiveServices.Api.Configuration;

namespace Glav.CognitiveServices.Api.Configuration.TextAnalytic
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
