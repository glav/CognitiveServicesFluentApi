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
            AddScoreLevelDefinition(new ScoreLevelBoundsDefinition(0, 0.35, "Negative"));
            AddScoreLevelDefinition(new ScoreLevelBoundsDefinition(0.35, 0.45, "Slightly Negative"));
            AddScoreLevelDefinition(new ScoreLevelBoundsDefinition(0.45, 0.55, "Neutral"));
            AddScoreLevelDefinition(new ScoreLevelBoundsDefinition(0.55, 0.75, "Slightly Positive"));
            AddScoreLevelDefinition(new ScoreLevelBoundsDefinition(0.75, 1, "Positive"));
        }

    }

}
