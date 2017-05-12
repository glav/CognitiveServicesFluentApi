using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain
{
    public class EmotionLevelIndicator
    {
        public EmotionLevelIndicator(double value, EmotionLevelTolerance tolerance)
        {
            if (tolerance == null)
            {
                throw new ArgumentNullException("Emotion tolerance levels cannot be NULL");
            }
            ToleranceLevel = tolerance;
            EmotionValue = value;
            DetermineEmotionLevel();
        }

        private void DetermineEmotionLevel()
        {
            if (EmotionValue == ToleranceLevel.NoIndication)
            {
                PercentConfidence = 100;
            } else
            {
                PercentConfidence = Math.Abs(EmotionValue) * 100;
            }

            EmotionRange = ToleranceLevel.EmotionValueIndicates(EmotionValue);
        }

        public EmotionRange EmotionRange { get; private set; }

        /// <summary>
        /// Determines the level of confidence in percent of the emotion reading.
        /// </summary>
        public double PercentConfidence { get; private set; }

        protected EmotionLevelTolerance ToleranceLevel { get; private set;}
        protected double EmotionValue { get; private set; }
    }

    public static class EmotionLevelIndicatorExtensions
    {
        public static bool MatchesAny(this EmotionLevelIndicator levelIndicator, params EmotionRange[] range)
        {
            return range.ToList().Contains(levelIndicator.EmotionRange);
        }
    }
}
