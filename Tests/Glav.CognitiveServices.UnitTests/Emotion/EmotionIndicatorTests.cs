using Xunit;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class EmotionIndicatorTests
    {
        private static DefaultScoreEvaluationEngine _scoreEngine = new DefaultScoreEvaluationEngine(new EmotionRangeScoreLevels());

        [Fact]
        public void EmotionValueShouldEvaluateToDefinitelyPositive()
        {
            var result = _scoreEngine.EvaluateScore(0.99);
            Assert.Equal(result.Name, EmotionRangeScoreLevels.DefinitelyPositive);
        }

        [Fact]
        public void EmotionValueShouldEvaluateToPossiblyPositive()
        {
            var result = _scoreEngine.EvaluateScore(0.74);
            Assert.Equal(result.Name, EmotionRangeScoreLevels.PossiblyPositive);
        }

        [Fact]
        public void EmotionValueShouldEvaluateToProbablyPositive()
        {
            var result = _scoreEngine.EvaluateScore(0.8);
            Assert.Equal(result.Name, EmotionRangeScoreLevels.ProbablyPositive);
        }

        [Fact]
        public void EmotionValueShouldEvaluateToDefinitelyNegative()
        {
            var result = _scoreEngine.EvaluateScore(0.1);
            Assert.Equal(result.Name, EmotionRangeScoreLevels.DefinitelyNegative);
        }

        [Fact]
        public void EmotionValueShouldEvaluateToPossiblyNegative()
        {
            var result = _scoreEngine.EvaluateScore(0.4);
            Assert.Equal(result.Name, EmotionRangeScoreLevels.PossiblyNegative);
        }

        [Fact]
        public void EmotionValueShouldEvaluateToProbablyNegative()
        {
            var result = _scoreEngine.EvaluateScore(0.2);
            Assert.Equal(result.Name, EmotionRangeScoreLevels.ProbablyNegative);
        }
    }
}
