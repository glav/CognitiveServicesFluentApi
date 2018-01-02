using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public class DefaultScoreEvaluationEngine
    {
        private readonly BaseScoreLevelsCollection _scoreLevelBoundsCollection;

        public DefaultScoreEvaluationEngine(BaseScoreLevelsCollection scoreLevelBoundsCollection)
        {
            _scoreLevelBoundsCollection = scoreLevelBoundsCollection;
        }

        public ScoreLevelBoundsDefinition EvaluateScore(long score)
        {
            _scoreLevelBoundsCollection.ValidateScoreLevelList();
            var result = _scoreLevelBoundsCollection.ScoreLevels.FirstOrDefault(s => s.LowerBound <= score && s.UpperBound > score);
            return result;
        }
    }
}
