using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class ConfigurationBuilderExtensions
    {
        public static ImageAnalysisSettings WithComputerVisionAnalysisActions(this CoreAnalysisSettings analysisSettings)
        {
            return new ImageAnalysisSettings(analysisSettings);
        }
    }
}
