using System;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class KeyPhraseServiceConfig : ApiServiceUriFragment
    {
        public override ApiActionCategory ApiCategory => ApiActionCategory.TextAnalytics;
        public override string Template => ApiConstants.TEXT_ANALYTIC_API_CATEGORY_PREFIX + "{0}/keyPhrases";
        public override string Version => ApiConstants.TEXT_ANALYTIC_VERSION;
    }
}
