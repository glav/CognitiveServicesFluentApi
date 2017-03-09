using Glav.CognitiveServices.Api.Configuration;
using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api
{
    public sealed class ApiAnalysisSettings
    {
        public ApiAnalysisSettings(ConfigurationSettings settings)
        {
            ActionsToPerform = new Dictionary<ApiActionType, IApiActionData>();
            ConfigurationSettings = settings;
        }
        public ConfigurationSettings ConfigurationSettings { get; private set; }
        public Dictionary<ApiActionType,IApiActionData> ActionsToPerform { get; private set; }
       
    }
}
