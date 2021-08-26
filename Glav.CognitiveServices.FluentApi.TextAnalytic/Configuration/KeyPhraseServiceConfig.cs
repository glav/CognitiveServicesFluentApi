using System;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class KeyPhraseServiceConfig : ApiServiceUriFragment
    {
        public KeyPhraseServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }

        public override string Template => ApiConstants.TEXT_ANALYTIC_API_CATEGORY_PREFIX + "{0}/keyPhrases";
        public override ApiActionDefinition ApiAction => TextAnalyticApiOperations.KeyPhraseAnalysis;
    }
}
