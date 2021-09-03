using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Configuration
{
    public class ReadImageAnalysisServiceConfig : ApiServiceUriFragment
    {
        public ReadImageAnalysisServiceConfig(string apiVersionIdentifier) : base(apiVersionIdentifier) { }
        public override string Template => "vision/{0}/read/analyze";

        public override ApiActionDefinition ApiAction => ComputerVisionApiOperations.ReadImage;
    }
}
