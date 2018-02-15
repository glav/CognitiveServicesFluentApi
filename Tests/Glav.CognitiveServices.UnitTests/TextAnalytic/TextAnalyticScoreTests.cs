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
            const double knownScore = 0.7988085;
            var input = "{\"documents\":[{\"score\":"+knownScore.ToString()+",\"id\":\"1\"}],\"errors\":[]}";
            var dummyResult = new MockCommsResult(input);
            var dummyEngine = new MockCommsEngine(dummyResult);

            // Run the dummy comms result through the pipeline
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", FluentApi.Core.LocationKeyIdentifier.EastUs2)
                .UsingCustomCommunication(dummyEngine)
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("this wont get analysed")
                .AnalyseAllAsync();

            // Calculate what we expect to get from our default score levels
            var defaultScoreLevels = new DefaultScoreLevels();  // this is the default set we are using.
            var expectedResult = defaultScoreLevels.ScoreLevels.FirstOrDefault(s => s.LowerBound <= knownScore && s.UpperBound >= knownScore);
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
            const double knownScore = 0.2;
            var input = "{\"documents\":[{\"score\":" + knownScore.ToString() + ",\"id\":\"1\"}],\"errors\":[]}";
            var dummyResult = new MockCommsResult(input);
            var dummyEngine = new MockCommsEngine(dummyResult);

            // Run the dummy comms result through the pipeline
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", FluentApi.Core.LocationKeyIdentifier.EastUs2)
                .UsingCustomCommunication(dummyEngine)
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("this wont get analysed")
                .AnalyseAllAsync();

            // Calculate what we expect to get from our score levels
            var scoreLevels = new CustomScoreLevels();  
            var expectedResult = scoreLevels.ScoreLevels.First();

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
