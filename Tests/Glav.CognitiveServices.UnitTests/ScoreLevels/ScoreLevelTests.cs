using Xunit;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System;
using System.Linq;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class ScoreLevelTests
    {
        [Fact]
        public void EmptyScoreLevelsShouldNotValidate()
        {
            var scoreEngine = new DefaultScoreEvaluationEngine(new EmptyScoreLevelCollection());
            Assert.Throws(typeof(CognitiveServicesArgumentException), () =>
             {
                 scoreEngine.EvaluateScore(1);
             });
        }

        [Fact]
        public void DefaultScoreLevelsShouldValidateAndDetectScore()
        {
            var scoreLevels = new DefaultScoreLevels();
            var scoreEngine = new DefaultScoreEvaluationEngine(scoreLevels);

            // Loop through all score level definitions and set the expected value just lower than the upperbound for each level so we ensure
            // that the expected result is that score.
            foreach (var expectedItem in scoreLevels.ScoreLevels)
            {
                var testValue = expectedItem.UpperBound - 0.0001;

                var result = scoreEngine.EvaluateScore(testValue);
                Assert.Equal(expectedItem.Name, result.Name);
            }

        }

        [Fact]
        public void InvalidScoreLevelCollectionWithNoEndLevelShouldNotValidate()
        {
            var scoreLevels = new InvalidScoreLevelCollectionNoEnd();
            var scoreEngine = new DefaultScoreEvaluationEngine(scoreLevels);
            Assert.Throws(typeof(CognitiveServicesException),() =>
            {
                scoreEngine.EvaluateScore(0.4);
            });
        }

        [Fact]
        public void InvalidScoreLevelCollectionWithNoStartLevelShouldNotValidate()
        {
            var scoreLevels = new InvalidScoreLevelCollectionNoStart();
            var scoreEngine = new DefaultScoreEvaluationEngine(scoreLevels);
            Assert.Throws(typeof(CognitiveServicesException), () =>
            {
                scoreEngine.EvaluateScore(0.4);
            });
        }

        [Fact]
        public void InvalidScoreLevelCollectionWithGapInSequenceLevelShouldNotValidate()
        {
            var scoreLevels = new InvalidScoreLevelCollectionHasGap();
            var scoreEngine = new DefaultScoreEvaluationEngine(scoreLevels);
            Assert.Throws(typeof(CognitiveServicesException), () =>
            {
                scoreEngine.EvaluateScore(0.4);
            });
        }


    }
}
