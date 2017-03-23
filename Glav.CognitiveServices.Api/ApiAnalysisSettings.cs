using Glav.CognitiveServices.Api.Communication;
using Glav.CognitiveServices.Api.Configuration;
using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api
{
    public sealed class ApiAnalysisSettings
    {
        private readonly ICommunicationEngine _communicationEngine;

        public ApiAnalysisSettings(ConfigurationSettings settings, ICommunicationEngine communicationEngine)
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
