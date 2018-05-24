using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core;
using System.Linq;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Diagnostics;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IAnalysisEngine<T> where T : IAnalysisResults
    {
        CoreAnalysisSettings AnalysisSettings { get; }

        Task<T> AnalyseAllAsync();
    }

    public abstract class BaseAnalysisEngine<TAnalysisResults> : IAnalysisEngine<TAnalysisResults>
                where TAnalysisResults : class, IAnalysisResults
    {
        public BaseAnalysisEngine(CoreAnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public CoreAnalysisSettings AnalysisSettings { get; protected set; }

        public abstract Task<TAnalysisResults> AnalyseAllAsync();

        public abstract Task AnalyseApiActionAsync(TAnalysisResults apiResults, ApiActionType apiAction);

        protected async Task AnalyseApiActionAsync(TAnalysisResults apiResults, ApiActionType apiAction, Action<ApiActionDataCollection, ICommunicationResult> apiActionHandler)
        {
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction))
            {
                // Get the collection of actions to perform for an API call
                var actions = AnalysisSettings.ActionsToPerform[apiAction];

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Serialising payload for {apiAction.ToString()}", "AnalyseAll");
                if (actions.SupportsBatchingMultipleItems)
                {
                    var urlQueryParams = actions.ToUrlQueryParameters();
                    var payload = actions.ToString();
                    await ExecuteApiActionAsync(apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger, actions, apiAction, apiActionHandler, urlQueryParams, payload);
                } else
                {
                    var allItems = actions.GetAllItems();
                    foreach(var item in allItems)
                    {
                        var urlQueryParams = string.Empty;  //TODO: Need to implement on individual data item
                        var payload = item.ToString();
                        await ExecuteApiActionAsync(apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger, actions, apiAction, apiActionHandler, "", payload);
                    }
                }
            }
        }

        private async Task ExecuteApiActionAsync(IDiagnosticLogger logger,
                ApiActionDataCollection apiActions,
                ApiActionType apiAction, Action<ApiActionDataCollection, ICommunicationResult> apiActionHandler, 
                string urlQueryParameters, string payload)
        {
            logger.LogInfo($"Calling service for {apiAction.ToString()}", "AnalyseAll");
            var result = await AnalysisSettings.CommunicationEngine.CallServiceAsync(apiAction, payload, urlQueryParameters).ConfigureAwait(continueOnCapturedContext: false);
            logger.LogInfo($"Processing results for {apiAction.ToString()}", "AnalyseAll");

            apiActionHandler(apiActions, result);
        }

    }
}