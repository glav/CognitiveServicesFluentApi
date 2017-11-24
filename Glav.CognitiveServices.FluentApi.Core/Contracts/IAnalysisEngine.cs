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

        public abstract Task AnalyseAllAsyncForAction(TAnalysisResults apiResults, ApiActionType apiAction);

        protected async Task AnalyseAllAsyncForAction(TAnalysisResults apiResults, ApiActionType apiAction, Action<IApiActionData, ICommunicationResult> apiActionHandler)
        {
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction))
            {
                var actions = AnalysisSettings.ActionsToPerform[apiAction];

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Serialising payload for {apiAction.ToString()}", "AnalyseAll");

                var payload = (actions as TActionData).ToString();

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Calling service for {apiAction.ToString()}", "AnalyseAll");
                var result = await AnalysisSettings.CommunicationEngine.CallServiceAsync(apiAction, payload);

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Processing results for {apiAction.ToString()}", "AnalyseAll");

                apiActionHandler(actions,result);
                //switch (apiAction)
                //{
                //    case ApiActionType.EmotionImageRecognition:
                //        apiResults.SetResult(new ImageRecognitionAnalysisContext((actions as EmotionActionData), new ImageRecognitionResult(result)));
                //        break;
                //    default:
                //        throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                //}
            }
        }

    }
}