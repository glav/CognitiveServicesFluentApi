using System;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class LanguageServiceConfig : ApiServiceUriFragment
    {
        public LanguageServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }

        public override string Template => ApiConstants.TEXT_ANALYTIC_API_CATEGORY_PREFIX + "{0}/languages";

        public override ApiActionDefinition ApiAction => TextAnalyticApiOperations.LanguageAnalysis;
    }
}
