using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public abstract class BaseScoreEvaluationEngine : IScoreEvaluationEngine
    {
        private readonly IScoreLevelBoundsCollection _scoreLevelBoundsCollection;

        protected BaseScoreEvaluationEngine(IScoreLevelBoundsCollection scoreLevelBoundsCollection)
        {
            _scoreLevelBoundsCollection = scoreLevelBoundsCollection;
        }
        public IScoreLevelBoundsCollection ScoreLevels => _scoreLevelBoundsCollection;

        public ScoreLevelBoundsDefinition EvaluateScore(double score)
        {
            ScoreLevels.ValidateScoreLevelList();
            return EvaluateScoreValue(score);
        }

        protected abstract ScoreLevelBoundsDefinition EvaluateScoreValue(double score);
    }
}
