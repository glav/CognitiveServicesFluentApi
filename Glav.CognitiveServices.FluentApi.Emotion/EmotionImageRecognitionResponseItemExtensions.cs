using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.Emotion.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion
{
    public static class EmotionImageRecognitionResponseItemExtensions
    {
        public static bool IsHappy(this EmotionImageRecognitionResponseItem recognitionItem)
        {
            return new EmotionLevelIndicator(recognitionItem.scores.happiness, new EmotionLevelTolerance()).MatchesAny(EmotionRange.ProbablyPositive, EmotionRange.DefinitelyPositive);
        }
    }
}
