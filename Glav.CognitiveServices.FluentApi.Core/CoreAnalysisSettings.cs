using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public class CoreAnalysisSettings : IAnalysisSettings
    {
        public CoreAnalysisSettings(ConfigurationSettings settings, ICommunicationEngine communicationEngine)
        {
            ActionsToPerform = new Dictionary<ApiActionType, IApiActionData>();
            ConfigurationSettings = settings;
            CommunicationEngine = communicationEngine;
        }

        public CoreAnalysisSettings(IAnalysisSettings analysisSettings)
        {
            ActionsToPerform = analysisSettings.ActionsToPerform;
            ConfigurationSettings = analysisSettings.ConfigurationSettings;
            CommunicationEngine = analysisSettings.CommunicationEngine;
        }

        public ConfigurationSettings ConfigurationSettings { get; private set; }
        public Dictionary<ApiActionType,IApiActionData> ActionsToPerform { get; private set; }
        public ICommunicationEngine CommunicationEngine { get; private set; }
       
    }

}
