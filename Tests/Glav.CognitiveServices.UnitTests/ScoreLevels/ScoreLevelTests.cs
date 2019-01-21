using Xunit;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System;
using System.Linq;
using Glav.CognitiveServices.FluentApi.Core;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.TextAnalytic;

namespace Glav.CognitiveServices.UnitTests.ScoreLevels
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

        [Fact]
        public async Task ShouldUtiliseCustomScoreLevel()
        {
            var langResult = "{\"documents\":[{\"id\":\"1\",\"detectedLanguages\":[{\"name\":\"English\",\"iso6391Name\":\"en\",\"score\":1.0},{\"name\":\"English\",\"iso6391Name\":\"en\",\"score\":0.45}]}],\"errors\":[]}";
            var commsEngine = new MockCommsEngine(new MockCommsResult(langResult));

            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("test", LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.None)
                .AddDebugDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithTextAnalyticAnalysisActions()
                .AddLanguageAnalysis("Can be anything here")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.LanguageAnalysis);
            Assert.NotEmpty(result.LanguageAnalysis.AnalysisResults);

            result.LanguageAnalysis.SetScoringEngine(new DefaultScoreEvaluationEngine(new CustomValidScoreLevelCollection()));

            var results = result.LanguageAnalysis.GetResults().ToList();
            Assert.Equal(2, results.First().detectedLanguages.Length);

            var scoreResult1 = result.LanguageAnalysis.Score(results[0].detectedLanguages[0]);
            Assert.NotNull(scoreResult1);
            Assert.Equal(CustomValidScoreLevelCollection.HighestScore, scoreResult1.Name);
            var scoreResult2 = result.LanguageAnalysis.Score(results[0].detectedLanguages[1]);
            Assert.NotNull(scoreResult2);
            Assert.Equal(CustomValidScoreLevelCollection.Level2Score, scoreResult2.Name);
        }



    }
}
