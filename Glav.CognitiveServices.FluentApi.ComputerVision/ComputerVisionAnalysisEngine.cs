using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public class ComputerVisionAnalysisEngine : IAnalysisEngine<ComputerVisionAnalysisResults>
    {
        public ComputerVisionAnalysisEngine(CoreAnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public CoreAnalysisSettings AnalysisSettings { get; private set; }

        public async Task<ComputerVisionAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new ComputerVisionAnalysisResults(AnalysisSettings);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.ComputerVisionImageAnalysis);
            return apiResults;

        }

        private async Task AnalyseAllAsyncForAction(ComputerVisionAnalysisResults apiResults, ApiActionType apiAction)
        {
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction))
            {
                var actions = AnalysisSettings.ActionsToPerform[apiAction];

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Serialising payload for {apiAction.ToString()}", "AnalyseAll");

                var payload = (actions as ImageAnalysisActionData).ToString();

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Calling service for {apiAction.ToString()}", "AnalyseAll");
                var result = await AnalysisSettings.CommunicationEngine.CallServiceAsync(apiAction, payload);

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Processing results for {apiAction.ToString()}", "AnalyseAll");

                switch (apiAction)
                {
                    case ApiActionType.ComputerVisionImageAnalysis:
                        apiResults.SetResult(new ImageAnalysisContext((actions as ImageAnalysisActionData), new ImageAnalysisResult(result)));
                        break;
                    default:
                        throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                }
            }
        }

    }
}
