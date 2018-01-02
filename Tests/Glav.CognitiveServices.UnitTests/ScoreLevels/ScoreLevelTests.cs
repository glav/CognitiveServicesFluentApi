using Xunit;
using System.Reflection;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class ScoreLevelTests
    {
        [Fact]
        public void EmptyScoreLevelsShouldNotValidate()
        {
            var scoreEngine = new DefaultScoreEvaluationEngine(new EmptyScoreLevelCollection());
            Assert.Throws(typeof(ArgumentException), () =>
             {
                 scoreEngine.EvaluateScore(1);
             });
        }

    }

    public class EmptyScoreLevelCollection : BaseScoreLevelsCollection
    {

    }
}
