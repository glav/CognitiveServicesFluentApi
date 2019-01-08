using System;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class FaceRangeScoreLevels : BaseScoreLevelsCollection
    {
        public const string DefinitelyNegative = "Definitely Negative";
        public const string ProbablyNegative = "Probably Negative";
        public const string PossiblyNegative = "Possibly Negative";
        public const string Neutral = "Neutral";
        public const string PossiblyPositive = "Possibly Positive";
        public const string ProbablyPositive = "Probably Positive";
        public const string DefinitelyPositive = "Definitely Positive";

        public FaceRangeScoreLevels()
        {
            ConstructLevels();
        }

        private void ConstructLevels()
        {
            AddStartingScoreLevel(0.15, DefinitelyNegative);
            AddNextScoreLevelDefinitionInList(0.35, ProbablyNegative);
            AddNextScoreLevelDefinitionInList(0.49, PossiblyNegative);
            AddNextScoreLevelDefinitionInList(0.51, Neutral);
            AddNextScoreLevelDefinitionInList(0.65, PossiblyPositive);
            AddNextScoreLevelDefinitionInList(0.85, ProbablyPositive);
            AddFinalScoreLevel(DefinitelyPositive);
        }
    }
}
