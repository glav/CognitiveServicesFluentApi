using System.Collections.Generic;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IAnalysisSettings
    {
        Dictionary<ApiActionType, IApiActionData> ActionsToPerform { get; }
        ICommunicationEngine CommunicationEngine { get; }
        ConfigurationSettings ConfigurationSettings { get; }
    }
}