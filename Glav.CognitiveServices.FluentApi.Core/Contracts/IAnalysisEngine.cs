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

        public abstract Task AnalyseApiActionAsync(TAnalysisResults apiResults, ApiActionDefinition apiAction);

        protected async Task AnalyseApiActionAsync(TAnalysisResults apiResults, ApiActionDefinition apiAction, Action<ApiActionDataCollection, ICommunicationResult> apiActionHandler)
        {
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction))
            {
                // Get the collection of actions to perform for an API call
                var actions = AnalysisSettings.ActionsToPerform[apiAction];

                if (actions.SupportsBatchingMultipleItems)
                {
                    var urlQueryParams = actions.ToUrlQueryParameters();
                    var payload = actions.ToString();
                    apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Serialising payload for {apiAction.ToString()}", "AnalyseApiAction");
                    // Note that the payload we are passing along is always a string. At this ApiActionCollection level, we do not support binary here, only for individual
                    // Api action items.
                    await ExecuteApiActionForActionCollectionAsync(apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger, actions, apiAction, apiActionHandler, urlQueryParams, payload);
                } else
                {
                    var allItems = actions.GetAllItems();

                    foreach(var item in allItems)
                    {
                        apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Serialising payload for {apiAction.ToString()}", "AnalyseApiAction");
                        await ExecuteApiActionForSingleApiActionAsync(apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger, actions, apiAction, apiActionHandler, item);
                    }
                }
            }
        }

        private async Task ExecuteApiActionForActionCollectionAsync(IDiagnosticLogger logger,
                ApiActionDataCollection apiActions,
                ApiActionDefinition apiAction, Action<ApiActionDataCollection, ICommunicationResult> apiActionHandler, 
                string urlQueryParameters, string payload)
        {
            logger.LogInfo($"Calling service for {apiAction.ToString()}", "ExecuteApiActionForActionCollectionAsync");
            var result = await AnalysisSettings.CommunicationEngine.CallServiceAsync(apiAction, payload, urlQueryParameters).ConfigureAwait(continueOnCapturedContext: false);
            logger.LogInfo($"Processing results for {apiAction.ToString()}", "ExecuteApiActionForActionCollectionAsync");

            apiActionHandler(apiActions, result);
        }

        private async Task ExecuteApiActionForSingleApiActionAsync(IDiagnosticLogger logger,
                ApiActionDataCollection apiActions,
                ApiActionDefinition apiAction, Action<ApiActionDataCollection, ICommunicationResult> apiActionHandler,
                IActionDataItem actionItem)
        {
            logger.LogInfo($"Calling service for {apiAction.ToString()}", "ExecuteApiActionForSingleApiActionAsync");
            var urlQueryParams = actionItem.ToUrlQueryParameters();
            ICommunicationResult commsResult;
            if (actionItem.IsBinaryData)
            {
                commsResult = await AnalysisSettings.CommunicationEngine.CallServiceAsync(apiAction, actionItem.ToBinary(), urlQueryParams).ConfigureAwait(continueOnCapturedContext: false);
            }
            else
            {
                commsResult = await AnalysisSettings.CommunicationEngine.CallServiceAsync(apiAction, actionItem.ToString(), urlQueryParams).ConfigureAwait(continueOnCapturedContext: false);
            }
            logger.LogInfo($"Processing results for {apiAction.ToString()}", "ExecuteApiActionForSingleApiActionAsync");

            apiActionHandler(apiActions, commsResult);
        }
    }
}