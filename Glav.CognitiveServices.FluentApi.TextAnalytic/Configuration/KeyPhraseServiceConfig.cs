using System;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class KeyPhraseServiceConfig : ApiServiceUriFragment
    {
        public override ApiActionCategory ApiCategory => ApiActionCategory.TextAnalytics;
        public override string Template => "text/analytics/{0}/keyPhrases";
        public override string Version => ApiConstants.TEXT_ANALYTIC_VERSION;
    }
}
