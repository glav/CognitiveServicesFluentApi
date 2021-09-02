using Xunit;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System.Linq;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class TextAnalyticScoreTests
    {
        [Fact]
        public async Task ShouldCalculateCorrectScoreFromDefaultSet()
        {
            // Prepare our dummy response
            var negativeInput = "{" +
                "\"documents\":[" +
                    "{\"sentiment\":\"negative\"," +
                        "\"confidenceScores\": " +
                            "{\"positive\": 0.0, \"neutral\":0.0,\"negative\":1.0 }," +
                        "\"id\":\"1\"}],\"errors\":[]}";

            var dummyResult = new MockCommsResult(negativeInput);
            var dummyEngine = new MockCommsEngine(dummyResult);

            // Run the dummy comms result through the pipeline
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", FluentApi.Core.LocationKeyIdentifier.EastUs2)
                .UsingCustomCommunication(dummyEngine)
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("this wont get analysed")
                .AnalyseAllAsync();

            // Calculate what we expect to get from our default score levels
            var defaultScoreLevels = new DefaultScoreLevels();  // this is the default set we are using.
            var expectedResult = defaultScoreLevels.ScoreLevels.FirstOrDefault(s => s.Name == DefaultScoreLevels.Negative);
            Assert.NotNull(expectedResult);

            // Check we got what we expect
            var actual = result.SentimentAnalysis.GetResults();
            Assert.Equal(1, actual.Count());
            var actualItem = actual.First();
            Assert.Equal(result.SentimentAnalysis.Score(actualItem).NormalisedName, expectedResult.NormalisedName);
            Assert.Equal(1, result.SentimentAnalysis.NumberOfResponses(expectedResult.Name));
        }

        [Fact]
        public async Task ShouldCalculateCorrectScoreFromCustomSet()
        {
            // Prepare our dummy response
            var positiveInput = "{" +
                "\"documents\":[" +
                    "{\"sentiment\":\"positive\"," +
                        "\"confidenceScores\": " +
                            "{\"positive\": 1.0, \"neutral\":0.0,\"negative\":0.0 }," +
                        "\"id\":\"1\"}],\"errors\":[]}";
            var dummyResult = new MockCommsResult(positiveInput);
            var dummyEngine = new MockCommsEngine(dummyResult);

            // Run the dummy comms result through the pipeline
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", FluentApi.Core.LocationKeyIdentifier.EastUs2)
                .UsingCustomCommunication(dummyEngine)
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("this wont get analysed")
                .AnalyseAllAsync();

            // Calculate what we expect to get from our score levels
            var scoreLevels = new CustomScoreLevels();
            var expectedResult = scoreLevels.ScoreLevels.Last();

            // override the scoring engine for sentiments
            result.SentimentAnalysis.UseCustomScoreLevelsAndDefaultScoringEngine(scoreLevels);

            // Check we got what we expect
            var actual = result.SentimentAnalysis.GetResults();
            Assert.Equal(1, actual.Count());

            var actualItem = actual.First();
            Assert.Equal(result.SentimentAnalysis.Score(actualItem).NormalisedName, expectedResult.NormalisedName);
            Assert.Equal(1, result.SentimentAnalysis.NumberOfResponses(expectedResult.Name));



        }
    }
}
