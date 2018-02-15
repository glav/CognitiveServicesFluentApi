using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.Emotion
{
    public class EmotionAnalysisEngine : IAnalysisEngine<EmotionAnalysisResults>
    {
        public EmotionAnalysisEngine(CoreAnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public CoreAnalysisSettings AnalysisSettings { get; private set; }

        public async Task<EmotionAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new EmotionAnalysisResults(AnalysisSettings);
            await AnalyseAllAsyncForAction(apiResults, ApiActionType.EmotionImageRecognition);
            return apiResults;

        }

        private async Task AnalyseAllAsyncForAction(EmotionAnalysisResults apiResults, ApiActionType apiAction)
        {
            if (AnalysisSettings.ActionsToPerform.ContainsKey(apiAction))
            {
                var actions = AnalysisSettings.ActionsToPerform[apiAction];

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Serialising payload for {apiAction.ToString()}", "AnalyseAll");

                var payload = (actions as EmotionActionData).ToString();

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Calling service for {apiAction.ToString()}", "AnalyseAll");
                var result = await AnalysisSettings.CommunicationEngine.CallServiceAsync(apiAction, payload);

                apiResults.AnalysisSettings.ConfigurationSettings.DiagnosticLogger.LogInfo($"Processing results for {apiAction.ToString()}", "AnalyseAll");

                // Set the emotion image recognition scoring levels to a more custom version
                var emotionDefaultScoringLevelsEngine = new DefaultScoreEvaluationEngine(new EmotionRangeScoreLevels());
                switch (apiAction)
                {
                    case ApiActionType.EmotionImageRecognition:
                        apiResults.SetResult(new ImageRecognitionAnalysisContext((actions as EmotionActionData), new ImageRecognitionResult(result), emotionDefaultScoringLevelsEngine));
                        break;
                    default:
                        throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                }
            }
        }

    }
}
