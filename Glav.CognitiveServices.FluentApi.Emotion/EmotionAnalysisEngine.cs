using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.Emotion
{
    public class EmotionAnalysisEngine : BaseAnalysisEngine<EmotionAnalysisResults, EmotionActionData>
    {
        public EmotionAnalysisEngine(CoreAnalysisSettings analysisSettings) : base (analysisSettings)
        {
        }

        public override async Task<EmotionAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new EmotionAnalysisResults(AnalysisSettings);
            await AnalyseApiActionAsync(apiResults, ApiActionType.EmotionImageRecognition);
            return apiResults;

        }

        public override async Task AnalyseApiActionAsync(EmotionAnalysisResults apiResults, ApiActionType apiAction)
        {
            await base.AnalyseApiActionAsync(apiResults, apiAction, (actionData, commsResult) =>
            {
                // Set the emotion image recognition scoring levels to a more custom version
                var emotionDefaultScoringLevelsEngine = new DefaultScoreEvaluationEngine(new EmotionRangeScoreLevels());
                switch (apiAction)
                {
                    case ApiActionType.EmotionImageRecognition:
                        apiResults.SetResult(new ImageRecognitionAnalysisContext((actionData as EmotionActionData), new ImageRecognitionResult(commsResult), emotionDefaultScoringLevelsEngine));
                        break;
                    default:
                        throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                }

            });

        }

    }
}
