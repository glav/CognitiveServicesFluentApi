using Xunit;
using System.Reflection;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class EmotionIndicatorTests
    {
        [Fact]
        public void EmotionValueShouldEvaluateToDefinitelyPositive()
        {
            var tolerance = new EmotionLevelTolerance();
            var result = tolerance.EmotionValueIndicates(0.99);
            Assert.Equal(result, EmotionRange.DefinitelyPositive);
        }

        [Fact]
        public void EmotionValueShouldEvaluateToPossiblyPositive()
        {
            var tolerance = new EmotionLevelTolerance();
            var result = tolerance.EmotionValueIndicates(0.35);
            Assert.Equal(result, EmotionRange.PossiblyPositive);
        }

        [Fact]
        public void EmotionValueShouldEvaluateToProbablyPositive()
        {
            var tolerance = new EmotionLevelTolerance();
            var result = tolerance.EmotionValueIndicates(0.75);
            Assert.Equal(result, EmotionRange.ProbablyPositive);
        }

        [Fact]
        public void EmotionValueShouldEvaluateToDefinitelyNegative()
        {
            var tolerance = new EmotionLevelTolerance();
            var result = tolerance.EmotionValueIndicates(-0.99);
            Assert.Equal(result, EmotionRange.DefinitelyNegative);
        }

        [Fact]
        public void EmotionValueShouldEvaluateToPossiblyNegative()
        {
            var tolerance = new EmotionLevelTolerance();
            var result = tolerance.EmotionValueIndicates(-0.35);
            Assert.Equal(result, EmotionRange.PossiblyNegative);
        }

        [Fact]
        public void EmotionValueShouldEvaluateToProbablyNegative()
        {
            var tolerance = new EmotionLevelTolerance();
            var result = tolerance.EmotionValueIndicates(-0.75);
            Assert.Equal(result, EmotionRange.ProbablyNegative);
        }
    }
}
