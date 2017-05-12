using Glav.CognitiveServices.FluentApi.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class TextAnalyticAnalysisSettings : CoreAnalysisSettings
    {
        public TextAnalyticAnalysisSettings(ConfigurationSettings settings, ICommunicationEngine communicationEngine) : base(settings, communicationEngine)
        {
        }

        public TextAnalyticAnalysisSettings(IAnalysisSettings analysisSettings) : base(analysisSettings)
        {

        }
    }
}
