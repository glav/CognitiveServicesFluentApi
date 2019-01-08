using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class CustomValidScoreLevelCollection : BaseScoreLevelsCollection
    {
        public const string LowestScore = "LowestScore";
        public const string Level1Score = "Level1Score";
        public const string Level2Score = "Level2Score";
        public const string Level3Score = "Level3Score";
        public const string HighestScore = "HighestScore";

        public CustomValidScoreLevelCollection()
        {
            AddStartingScoreLevel(0.2, "LowestScore");
            AddNextScoreLevelDefinitionInList(0.4, "Level1Score");
            AddNextScoreLevelDefinitionInList(0.6, "Level2Score");
            AddNextScoreLevelDefinitionInList(0.8, "Level3Score");
            AddFinalScoreLevel("HighestScore");
        }
    }

}
