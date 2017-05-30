using System;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class SentimentServiceConfig : ApiServiceUriFragment
    {
        public override ApiActionCategory ApiCategory => ApiActionCategory.TextAnalytics;
        public override string Template => "text/analytics/{0}/sentiment";
        public override string Version => ApiConstants.TEXT_ANALYTIC_VERSION;

    }
}
