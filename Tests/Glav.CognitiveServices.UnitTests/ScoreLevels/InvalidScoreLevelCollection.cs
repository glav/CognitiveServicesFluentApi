using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.UnitTests.ScoreLevels
{
    public class InvalidScoreLevelCollectionNoEnd : BaseScoreLevelsCollection
    {
        public InvalidScoreLevelCollectionNoEnd()
        {
            AddStartingScoreLevel(0.2, "Start");
            AddNextScoreLevelDefinitionInList(0.7, "Last");
        }
    }

    public class InvalidScoreLevelCollectionNoStart : BaseScoreLevelsCollection
    {
        public InvalidScoreLevelCollectionNoStart()
        {
            AddScoreLevelDefinition(0.2,0.4, "Start");
            AddNextScoreLevelDefinitionInList(0.7, "Last");
        }
    }

    public class InvalidScoreLevelCollectionHasGap : BaseScoreLevelsCollection
    {
        public InvalidScoreLevelCollectionHasGap()
        {
            AddStartingScoreLevel(0.2, "Start");
            AddScoreLevelDefinition(0.4, 0.7, "Middle");
            AddFinalScoreLevel("End");
        }
    }
}
