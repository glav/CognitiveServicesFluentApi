using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Configuration
{
    public class RecognizeTextAnalysisServiceConfig : ApiServiceUriFragment
    {
        public override string Template => "vision/{0}/recognizeText";

        public override string Version => ApiConstants.ComputerVisionVersion;

        public override ApiActionCategory ApiCategory => ApiActionCategory.ComputerVision;
    }
}
