using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.Emotion.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion
{
    public static class EmotionImageRecognitionResponseItemExtensions
    {
        public static bool IsHappy(this ImageRecognitionAnalysisContext context, EmotionImageRecognitionResponseItem recognitionItem)
        {
            var score = context.ScoringEngine.EvaluateScore(recognitionItem.scores.happiness);
            return score.Name == EmotionRangeScoreLevels.DefinitelyPositive || score.Name == EmotionRangeScoreLevels.ProbablyPositive;
        }
    }
}
