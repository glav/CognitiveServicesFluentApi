using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public class SentimentCustomScoreEvaluationEngine : IScoreEvaluationEngine<SentimentResultResponseItem>
    {
        private readonly IScoreLevelBoundsCollection _scoreLevelBoundsCollection;

        public SentimentCustomScoreEvaluationEngine(IScoreLevelBoundsCollection scoreLevelBoundsCollection)
        {
            _scoreLevelBoundsCollection = scoreLevelBoundsCollection;
        }

        public IScoreLevelBoundsCollection ScoreLevels => _scoreLevelBoundsCollection;

        public ScoreLevelBoundsDefinition Evaluate(SentimentResultResponseItem item)
        {
            var foundItem = _scoreLevelBoundsCollection.ScoreLevels.FirstOrDefault(s => s.NormalisedName == item.sentiment.ToLowerInvariant());
            if (foundItem == null)
            {
                //throw new ScoreEvaluationException("Score level not found");
            }
            return foundItem;
        }
    }
}
