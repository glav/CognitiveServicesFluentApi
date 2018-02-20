using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public class DefaultScoreEvaluationEngine : BaseScoreEvaluationEngine
    {
        public DefaultScoreEvaluationEngine(IScoreLevelBoundsCollection scoreLevelBoundsCollection) : base(scoreLevelBoundsCollection)
        {
        }

        protected override ScoreLevelBoundsDefinition EvaluateScoreValue(double score)
        {
            if (score == 1)
            {
                return ScoreLevels.ScoreLevels.Last();
            }
            var result = ScoreLevels.ScoreLevels.FirstOrDefault(s => s.LowerBound <= score && s.UpperBound > score);
            return result;
        }
    }
}
