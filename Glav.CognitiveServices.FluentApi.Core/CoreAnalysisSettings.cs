using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public class CoreAnalysisSettings : IAnalysisSettings
    {
        public CoreAnalysisSettings(ConfigurationSettings settings, ICommunicationEngine communicationEngine)
        {
            ActionsToPerform = new Dictionary<string, ApiActionDataCollection>();
            ConfigurationSettings = settings;
            CommunicationEngine = communicationEngine;
        }

        public CoreAnalysisSettings(IAnalysisSettings analysisSettings)
        {
            if (analysisSettings == null)
            {
                throw new CognitiveServicesArgumentException("AnalysisSettings cannot be NULL");
            }
            if (analysisSettings.ActionsToPerform == null)
            {
                throw new CognitiveServicesArgumentException("ActionsToPerform cannot be NULL");
            }
            if (analysisSettings.ConfigurationSettings == null)
            {
                throw new CognitiveServicesArgumentException("ConfigurationSettings cannot be NULL");
            }
            if (analysisSettings.CommunicationEngine == null)
            {
                throw new CognitiveServicesArgumentException("CommunicationEngine cannot be NULL");
            }

            ActionsToPerform = analysisSettings.ActionsToPerform;
            ConfigurationSettings = analysisSettings.ConfigurationSettings;
            CommunicationEngine = analysisSettings.CommunicationEngine;
        }

        public ConfigurationSettings ConfigurationSettings { get; private set; }
        public Dictionary<string, ApiActionDataCollection> ActionsToPerform { get; private set; }
        public ICommunicationEngine CommunicationEngine { get; private set; }

        public T GetOrCreateActionDataInstance<T>(ApiActionDefinition actionType) where T : ApiActionDataCollection, new()
        {
            if (!ActionsToPerform.ContainsKey(actionType.Name))
            {
                var data = new T();
                ActionsToPerform.Add(actionType.Name, data);
            }

            return ActionsToPerform[actionType.Name] as T;
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();
            buffer.AppendLine($"Communications: {this.CommunicationEngine.ToString()}");
            buffer.Append(ConfigurationSettings.ToString());
            buffer.AppendLine("Actions to perform:");
            foreach (var action in ActionsToPerform)
            {
                buffer.AppendLine($"\t{action.Key}");
            }

            return buffer.ToString();

        }

    }

}
