using System;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class TopicServiceConfig : ApiServiceUriFragment
    {
        public override ApiActionCategory ApiCategory => ApiActionCategory.TextAnalytics;
        public override string Template => "text/analytics/{0}/topics";
        public override string Version => ApiConstants.TEXT_ANALYTIC_VERSION;

    }
}
