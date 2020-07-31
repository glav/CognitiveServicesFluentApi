using Glav.CognitiveServices.FluentApi.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Luis.Configuration
{
    public class LuisAnalysisSettings : CoreAnalysisSettings
    {
        public LuisAnalysisSettings(ConfigurationSettings settings, ICommunicationEngine communicationEngine) : base(settings, communicationEngine)
        {
        }

        public LuisAnalysisSettings(IAnalysisSettings analysisSettings) : base(analysisSettings)
        {

        }
    }
}
