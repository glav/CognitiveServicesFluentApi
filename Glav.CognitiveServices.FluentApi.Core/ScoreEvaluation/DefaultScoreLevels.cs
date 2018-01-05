using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public class DefaultScoreLevels : BaseScoreLevelsCollection
    {
        public DefaultScoreLevels()
        {
            ConstructDefaultValues();
        }

        private void ConstructDefaultValues()
        {
            AddStartingScoreLevel(0.35, "Negative");
            AddNextScoreLevelDefinitionInList(0.45, "Slightly Negative");
            AddNextScoreLevelDefinitionInList(0.55, "Neutral");
            AddNextScoreLevelDefinitionInList(0.75, "Slightly Positive");
            AddFinalScoreLevel("Positive");
        }

    }

}
