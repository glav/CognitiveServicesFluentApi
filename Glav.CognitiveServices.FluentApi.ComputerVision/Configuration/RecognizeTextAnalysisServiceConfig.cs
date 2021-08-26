using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Configuration
{
    public class RecognizeTextAnalysisServiceConfig : ApiServiceUriFragment
    {
        public RecognizeTextAnalysisServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "vision/{0}/recognizeText";

        public override ApiActionDefinition ApiAction => ComputerVisionApiOperations.RecognizeText;
    }
}
