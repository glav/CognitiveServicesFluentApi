using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public class NumericScoreEvaluationEngine : IScoreEvaluationEngine<double>
    {
        private readonly IScoreLevelBoundsCollection _scoreLevelBoundsCollection;

        public NumericScoreEvaluationEngine(IScoreLevelBoundsCollection scoreLevelBoundsCollection)
        {
            _scoreLevelBoundsCollection = scoreLevelBoundsCollection;
        }
        public IScoreLevelBoundsCollection ScoreLevels => _scoreLevelBoundsCollection;

        public ScoreLevelBoundsDefinition Evaluate(double item)
        {
            ScoreLevels.ValidateScoreLevelList();
            if (item == 1)
            {
                return ScoreLevels.ScoreLevels.Last();
            }
            var result = ScoreLevels.ScoreLevels.FirstOrDefault(s => s.LowerBound <= item && s.UpperBound > item);
            return result;
        }

    }
}
