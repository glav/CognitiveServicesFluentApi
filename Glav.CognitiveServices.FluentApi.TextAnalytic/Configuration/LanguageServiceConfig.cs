using System;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class LanguageServiceConfig : ApiServiceUriFragment
    {
        public override ApiActionCategory ApiCategory => ApiActionCategory.TextAnalytics;
        public override string Template => ApiConstants.TEXT_ANALYTIC_API_CATEGORY_PREFIX + "{0}/languages";
        public override string Version => ApiConstants.TEXT_ANALYTIC_VERSION;

    }
}
