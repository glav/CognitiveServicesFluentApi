using System.Threading.Tasks;
using System.Linq;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Diagnostics;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.Core.Analysis
{
    public abstract class BaseAnalysisEngine<TAnalysisResults> : IAnalysisEngine<TAnalysisResults>
                where TAnalysisResults : class, IAnalysisResults
    {
        protected BaseAnalysisEngine(CoreAnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public CoreAnalysisSettings AnalysisSettings { get; protected set; }

        public abstract Task<TAnalysisResults> AnalyseAllAsync();

        public abstract Task AnalyseApiActionAsync(TAnalysisResults apiResults, ApiActionDefinition apiAction);

        protected async Task AnalyseApiActionAsync(ApiActionDefinition apiAction, Action<ApiActionDataCollection, ICommunicationResult> apiActionHandler)
        {
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction.Name))
            {
                await AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfoAsync(AnalysisSettings.ToString(), "Analysis Settings");

                // Get the collection of actions to perform for an API call
                var actions = AnalysisSettings.ActionsToPerform[apiAction.Name];

                // In other words, if we can group the multiple actions into a single payload.
                if (actions.SupportsBatchingMultipleItems)
                {
                    // Note that the payload we are passing along is always a string. At this ApiActionCollection level, we do not support binary here, only for individual
                    // Api action items.
                    await ExecuteApiActionForActionCollectionAsync(actions, apiActionHandler);
                }
                else
                {
                    var allItems = actions.GetAllItems();

                    foreach (var item in allItems)
                    {
                        await ExecuteApiActionForSingleApiActionAsync(actions, apiAction, apiActionHandler, item);
                    }
                }
            }
        }

        private async Task ExecuteApiActionForActionCollectionAsync(ApiActionDataCollection actionCollection, Action<ApiActionDataCollection, ICommunicationResult> apiActionHandler)
        {
            var logger = AnalysisSettings.ConfigurationSettings.DiagnosticLogger;
            var firstAction = actionCollection.GetAllItems().First();

            await logger.LogInfoAsync($"Calling service for {firstAction.ToString()}", "ExecuteApiActionForActionCollectionAsync");
            var result = await AnalysisSettings.CommunicationEngine.CallBatchServiceAsync(actionCollection).ConfigureAwait(continueOnCapturedContext: false);
            await logger.LogInfoAsync($"Processing results for {firstAction.ToString()}", "ExecuteApiActionForActionCollectionAsync");

            apiActionHandler(actionCollection, result);
        }

        private async Task ExecuteApiActionForSingleApiActionAsync(ApiActionDataCollection apiActions,
                ApiActionDefinition apiAction, Action<ApiActionDataCollection, ICommunicationResult> apiActionHandler,
                IActionDataItem actionItem)
        {
            var logger = AnalysisSettings.ConfigurationSettings.DiagnosticLogger;
            await logger.LogInfoAsync($"Calling service for {apiAction.ToString()}", "ExecuteApiActionForSingleApiActionAsync");
            var commsResult = await AnalysisSettings.CommunicationEngine
                                    .CallServiceAsync(actionItem)
                                    .ConfigureAwait(continueOnCapturedContext: false);
            await logger.LogInfoAsync($"Processing results for {apiAction.ToString()}", "ExecuteApiActionForSingleApiActionAsync");

            apiActionHandler(apiActions, commsResult);
        }
    }
}