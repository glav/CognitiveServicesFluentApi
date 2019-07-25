using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public class DefaultScoreLevels : BaseScoreLevelsCollection
    {
        public const string Negative = "Negative";
        public const string SlightlyNegative = "Slightly Negative";
        public const string Neutral = "Neutral";
        public const string SlightlyPositive = "Slightly Positive";
        public const string Positive = "Positive";

        public DefaultScoreLevels()
        {
            ConstructDefaultValues();
        }

        private void ConstructDefaultValues()
        {
            AddStartingScoreLevel(0.35, Negative);
            AddNextScoreLevelDefinitionInList(0.45, SlightlyNegative);
            AddNextScoreLevelDefinitionInList(0.55, Neutral);
            AddNextScoreLevelDefinitionInList(0.75, SlightlyPositive);
            AddFinalScoreLevel(Positive);
        }

    }

}
