using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Emotion.Domain
{
    public class EmotionLevelTolerance
    {
        public EmotionLevelTolerance()
        {
            NoIndication = DefaultNoIndication;
            MildConfidence = DefaultMildConfidence;
            AbsoluteConfidence = DefaultAbsoluteConfidence;
        }

        /// <summary>
        /// Tolerance level overrides. Could be fed in via config
        /// </summary>
        /// <param name="mildConfidenceTolerance"></param>
        /// <param name="absolutelyPositiveValue"></param>
        /// <param name="negativeValue"></param>
        /// <param name="absolutelyNegativeValue"></param>
        public EmotionLevelTolerance(double mildConfidenceTolerance, double absoluteConfidenceTolerance)
        {
            NoIndication = DefaultNoIndication;
            MildConfidence = mildConfidenceTolerance;
            AbsoluteConfidence = absoluteConfidenceTolerance;
        }

        public EmotionRange EmotionValueIndicates(double value)
        {
            if (value > NoIndication && value <= MildConfidence)
            {
                return EmotionRange.PossiblyPositive;
            }
            if (value > MildConfidence && value < AbsoluteConfidence)
            {
                return EmotionRange.ProbablyPositive;
            }
            if (value >= AbsoluteConfidence)
            {
                return EmotionRange.DefinitelyPositive;
            }

            if (value < NoIndication && value >= -MildConfidence)
            {
                return EmotionRange.PossiblyNegative;
            }
            if (value < -MildConfidence && value > -AbsoluteConfidence)
            {
                return EmotionRange.ProbablyNegative;
            }
            if (value <= -AbsoluteConfidence)
            {
                return EmotionRange.DefinitelyNegative;
            }
            return EmotionRange.None;
        }

        public const double DefaultNoIndication = 0;
        public const double DefaultMildConfidence = 0.5;
        public const double DefaultAbsoluteConfidence = 0.9;

        public double NoIndication { get; private set; }
        public double MildConfidence { get; private set; }
        public double AbsoluteConfidence { get; private set; }
    }
}
