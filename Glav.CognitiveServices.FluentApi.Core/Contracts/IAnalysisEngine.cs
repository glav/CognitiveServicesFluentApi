using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IAnalysisEngine<T> where T : IAnalysisResults
    {
        CoreAnalysisSettings AnalysisSettings { get; }

        Task<T> AnalyseAllAsync();
    }

    public abstract class BaseAnalysisEngine<TAnalysisResults, TActionData> : IAnalysisEngine<TAnalysisResults>
                where TAnalysisResults : class, IAnalysisResults
                where TActionData : class, IApiActionData
    {
        public BaseAnalysisEngine(CoreAnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public CoreAnalysisSettings AnalysisSettings { get; protected set; }

        public abstract Task<TAnalysisResults> AnalyseAllAsync();

        public abstract Task AnalyseApiActionAsync(TAnalysisResults apiResults, ApiActionType apiAction);

        protected async Task AnalyseApiActionAsync(TAnalysisResults apiResults, ApiActionType apiAction, Action<IApiActionData, ICommunicationResult> apiActionHandler)
        {
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction))
            {
                var actions = AnalysisSettings.ActionsToPerform[apiAction];

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Serialising payload for {apiAction.ToString()}", "AnalyseAll");

                var concreteAction = (actions as TActionData);
                var urlQueryParams = concreteAction.ToUrlQueryParameters();
                var payload = concreteAction.ToString();

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Calling service for {apiAction.ToString()}", "AnalyseAll");
                var result = await AnalysisSettings.CommunicationEngine.CallServiceAsync(apiAction, payload, urlQueryParams).ConfigureAwait(continueOnCapturedContext: false);

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Processing results for {apiAction.ToString()}", "AnalyseAll");

                apiActionHandler(actions,result);
            }
        }

    }
}