using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public sealed class AnalysisSettings
    {
        private readonly ICommunicationEngine _communicationEngine;

        public AnalysisSettings(ConfigurationSettings settings, ICommunicationEngine communicationEngine)
        {
            ActionsToPerform = new Dictionary<ApiActionType, IApiActionData>();
            ConfigurationSettings = settings;
            _communicationEngine = communicationEngine;
        }

        public ConfigurationSettings ConfigurationSettings { get; private set; }
        public Dictionary<ApiActionType,IApiActionData> ActionsToPerform { get; private set; }
        public ICommunicationEngine CommunicationEngine { get { return _communicationEngine; }}
       
    }

}
