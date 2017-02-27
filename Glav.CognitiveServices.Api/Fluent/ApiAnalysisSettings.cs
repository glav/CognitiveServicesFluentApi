using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public sealed class ApiAnalysisSettings
    {
        public ApiAnalysisSettings(ConfigurationSettings settings)
        {
            ActionsToPerform = new List<ApiAction>();
            ConfigurationSettings = settings;
        }
        public ConfigurationSettings ConfigurationSettings { get; private set; }
        public List<ApiAction> ActionsToPerform { get; private set; }
    }
}
