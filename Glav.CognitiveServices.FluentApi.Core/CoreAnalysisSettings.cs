using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public class CoreAnalysisSettings : IAnalysisSettings
    {
        public CoreAnalysisSettings(ConfigurationSettings settings, ICommunicationEngine communicationEngine)
        {
            ActionsToPerform = new Dictionary<ApiActionType, IApiActionDataCollection>();
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
        public Dictionary<ApiActionType, IApiActionDataCollection> ActionsToPerform { get; private set; }
        public ICommunicationEngine CommunicationEngine { get; private set; }

        public T GetOrCreateActionDataInstance<T>(ApiActionType actionType) where T : class, IApiActionDataCollection, new()
        {
            if (!ActionsToPerform.ContainsKey(actionType))
            {
                var data = new T();
                ActionsToPerform.Add(actionType, data);
            }

            return ActionsToPerform[actionType] as T;
        }

    }

}
