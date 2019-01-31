using System;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class OperationStatusServiceConfig : ApiServiceUriFragment
    {
        public override string Template => "text/analytics/{0}/operations";
        public override string Version => ApiConstants.TEXT_ANALYTIC_VERSION;

        public override ApiActionDefinition ApiAction => TextAnalyticApiOperations.OperationStatus;
    }
}
