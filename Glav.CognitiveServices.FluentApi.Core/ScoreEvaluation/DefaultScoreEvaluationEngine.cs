using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public class DefaultScoreEvaluationEngine : IScoreEvaluationEngine
    {
        private readonly IScoreLevelBoundsCollection _scoreLevelBoundsCollection;

        public DefaultScoreEvaluationEngine(IScoreLevelBoundsCollection scoreLevelBoundsCollection)
        {
            _scoreLevelBoundsCollection = scoreLevelBoundsCollection;
        }

        public ScoreLevelBoundsDefinition EvaluateScore(double score)
        {
            _scoreLevelBoundsCollection.ValidateScoreLevelList();
            if (score == 1)
            {
                return _scoreLevelBoundsCollection.ScoreLevels.Last();
            }
            var result = _scoreLevelBoundsCollection.ScoreLevels.FirstOrDefault(s => s.LowerBound <= score && s.UpperBound > score);
            return result;
        }
    }
}
