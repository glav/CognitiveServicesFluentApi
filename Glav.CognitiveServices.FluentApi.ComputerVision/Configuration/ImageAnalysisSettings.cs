using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Configuration
{
    public class ImageAnalysisSettings : CoreAnalysisSettings
    {
        public ImageAnalysisSettings(ConfigurationSettings settings, ICommunicationEngine communicationEngine) : base(settings, communicationEngine)
        {
        }

        public ImageAnalysisSettings(IAnalysisSettings analysisSettings) : base(analysisSettings)
        {

        }

    }
}
