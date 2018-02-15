using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.UnitTests
{
    public class CustomScoreLevels : BaseScoreLevelsCollection
    {
        public CustomScoreLevels()
        {
            ConstructDefaultValues();
        }

        private void ConstructDefaultValues()
        {
            AddStartingScoreLevel(0.3, "Very Low");
            AddNextScoreLevelDefinitionInList(0.4, "Somewhat low");
            AddNextScoreLevelDefinitionInList(0.6, "Middle");
            AddNextScoreLevelDefinitionInList(0.8, "High");
            AddFinalScoreLevel("Really Highs");
        }

    }
}
