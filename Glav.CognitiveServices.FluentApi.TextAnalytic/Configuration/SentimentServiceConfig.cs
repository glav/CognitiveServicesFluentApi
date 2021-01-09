using System;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class SentimentServiceConfig : ApiServiceUriFragment
    {
        public override string Template => ApiConstants.TEXT_ANALYTIC_API_CATEGORY_PREFIX + "{0}/sentiment";
        public override string Version => ApiConstants.DEFAULT_TEXT_ANALYTIC_VERSION;

        public override ApiActionDefinition ApiAction => TextAnalyticApiOperations.SentimentAnalysis;
    }
}
