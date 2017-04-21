using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
        public class KeyPhraseServiceConfig : BaseApiServiceUriFragment
        {
            public KeyPhraseServiceConfig()
            {
                Version = ApiConstants.TEXT_ANALYTIC_VERSION;
                Template = "text/analytics/{0}/keyPhrases";
            }

        }
}
