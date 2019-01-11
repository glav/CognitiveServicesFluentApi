using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face.Configuration;

namespace Glav.CognitiveServices.FluentApi.Face
{
    public static class ConfigurationBuilderExtensions
    {
        public static FaceAnalysisSettings WithFaceAnalysisActions(this CoreAnalysisSettings analysisSettings)
        {
            return new FaceAnalysisSettings(analysisSettings);
        }


    }
}
