using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Face.Configuration
{
    public class FaceAnalysisSettings : CoreAnalysisSettings
    {
        public FaceAnalysisSettings(ConfigurationSettings settings, ICommunicationEngine communicationEngine) : base(settings, communicationEngine)
        {
        }

        public FaceAnalysisSettings(IAnalysisSettings analysisSettings) : base(analysisSettings)
        {

        }
    }
}
