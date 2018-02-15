using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Emotion.Configuration
{
    public class EmotionAnalysisSettings : CoreAnalysisSettings
    {
        public EmotionAnalysisSettings(ConfigurationSettings settings, ICommunicationEngine communicationEngine) : base(settings, communicationEngine)
        {
        }

        public EmotionAnalysisSettings(IAnalysisSettings analysisSettings) : base(analysisSettings)
        {
        }
    }
}