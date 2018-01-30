using Xunit;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Emotion;
using System.Linq;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class EmotionScoreTests
    {
        [Fact]
        public async Task ShouldCalculateCorrectScoreFromDefaultSet()
        {
            // Prepare our dummy response
            var input = "[  {    \"faceRectangle\": {       \"left\": 68,       \"top\": 97,       \"width\": 64,       \"height\": 97     }" +
                            ",     \"scores\": {       \"anger\": 0.00300731952,       \"contempt\": 5.14648448E-08,       \"disgust\": 9.180124E-06," +
                            "       \"fear\": 0.0001912825,       \"happiness\": 0.9875571,       \"neutral\": 0.0009861537,       \"sadness\": 1.889955E-05," +
                            "       \"surprise\": 0.008229999     }   } ]";
            var dummyResult = new MockCommsResult(input);
            var dummyEngine = new MockCommsEngine(dummyResult);

            // Run the dummy comms result through the pipeline
            var result = await EmotionConfigurationSettings.CreateUsingConfigurationKeys("123", FluentApi.Core.LocationKeyIdentifier.EastUs2)
                .UsingDefaultGlobalScoringEngineAndScoreLevels()
                .UsingCustomCommunication(dummyEngine)
                .WithEmotionAnalysisActions()
                .AddImageRecognition("http://fakeurl.com/wont/get/called")
                .AnalyseAllEmotionsAsync();

            // Check we got what we expect
            var actual = result.ImageRecognitionAnalysis.GetFacesRecognised();
            Assert.Equal(1, actual.Count());
            var actualItem = actual.First();

            Assert.Equal(EmotionRangeScoreLevels.DefinitelyNegative,
                result.ImageRecognitionAnalysis.ScoringEngine.EvaluateScore(actualItem.scores.anger).Name);
            Assert.Equal(EmotionRangeScoreLevels.DefinitelyNegative, 
                result.ImageRecognitionAnalysis.ScoringEngine.EvaluateScore(actualItem.scores.contempt).Name);
            Assert.Equal(EmotionRangeScoreLevels.DefinitelyNegative,
                result.ImageRecognitionAnalysis.ScoringEngine.EvaluateScore(actualItem.scores.disgust).Name);
            Assert.Equal(EmotionRangeScoreLevels.DefinitelyNegative,
                result.ImageRecognitionAnalysis.ScoringEngine.EvaluateScore(actualItem.scores.fear).Name);
            Assert.Equal(EmotionRangeScoreLevels.DefinitelyPositive,
                result.ImageRecognitionAnalysis.ScoringEngine.EvaluateScore(actualItem.scores.happiness).Name);
            Assert.Equal(EmotionRangeScoreLevels.DefinitelyNegative,
                result.ImageRecognitionAnalysis.ScoringEngine.EvaluateScore(actualItem.scores.sadness).Name);
            Assert.Equal(EmotionRangeScoreLevels.DefinitelyNegative,
                result.ImageRecognitionAnalysis.ScoringEngine.EvaluateScore(actualItem.scores.surprise).Name);
        }

        [Fact]
        public async Task ShouldGetAngryFacesFromDefaultSet()
        {
            // Prepare our dummy response
            var input = "[  {    \"faceRectangle\": {       \"left\": 68,       \"top\": 97,       \"width\": 64,       \"height\": 97     }" +
                            ",     \"scores\": {       \"anger\": 0.89300731952,       \"contempt\": 5.14648448E-08,       \"disgust\": 9.180124E-06," +
                            "       \"fear\": 0.0001912825,       \"happiness\": 0.0005571,       \"neutral\": 0.0009861537,       \"sadness\": 1.889955E-05," +
                            "       \"surprise\": 0.008229999     }   },"+
                            "{    \"faceRectangle\": {       \"left\": 68,       \"top\": 97,       \"width\": 64,       \"height\": 97     }" +
                            ",     \"scores\": {       \"anger\": 1,       \"contempt\": 5.14648448E-08,       \"disgust\": 9.180124E-06," +
                            "       \"fear\": 0.0001912825,       \"happiness\": 0.1875571,       \"neutral\": 0.0009861537,       \"sadness\": 1.889955E-05," +
                            "       \"surprise\": 0.008229999     }   },"+
                            "{    \"faceRectangle\": {       \"left\": 68,       \"top\": 97,       \"width\": 64,       \"height\": 97     }" +
                            ",     \"scores\": {       \"anger\": 4.14648448E-08,       \"contempt\": 5.14648448E-08,       \"disgust\": 9.180124E-06," +
                            "       \"fear\": 0.0001912825,       \"happiness\": 0.9875571,       \"neutral\": 0.0009861537,       \"sadness\": 1.889955E-05," +
                            "       \"surprise\": 0.008229999     }   }]";
            var dummyResult = new MockCommsResult(input);
            var dummyEngine = new MockCommsEngine(dummyResult);

            // Run the dummy comms result through the pipeline
            var result = await EmotionConfigurationSettings.CreateUsingConfigurationKeys("123", FluentApi.Core.LocationKeyIdentifier.EastUs2)
                .UsingDefaultGlobalScoringEngineAndScoreLevels()
                .UsingCustomCommunication(dummyEngine)
                .WithEmotionAnalysisActions()
                .AddImageRecognition("http://fakeurl.com/wont/get/called")
                .AnalyseAllEmotionsAsync();

            // Check we got what we expect
            var actuals = result.ImageRecognitionAnalysis.GetFacesRecognised();
            Assert.Equal(3, actuals.Count());

            var angryFaces = result.ImageRecognitionAnalysis.GetAngryFaces();
            Assert.Equal(2, angryFaces.Count());
        }

    }
}
