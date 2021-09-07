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
                // We may be using a set of custom score levels so may not match the return result of the sentiment analysis
                // so we try and figure it out based on actual scores instead of the text result returned by sentiment analysis
                if (item.confidenceScores.positive > item.confidenceScores.negative && item.confidenceScores.positive > item.confidenceScores.neutral)
                {
                    return _scoreLevelBoundsCollection.ScoreLevels.OrderByDescending(o => o.UpperBound).First();
                }
                if (item.confidenceScores.negative > item.confidenceScores.neutral && item.confidenceScores.negative> item.confidenceScores.positive)
                {
                    return _scoreLevelBoundsCollection.ScoreLevels.OrderBy(o => o.LowerBound).First();
                }
                if (item.confidenceScores.neutral > item.confidenceScores.positive && item.confidenceScores.neutral > item.confidenceScores.negative)
                {
                    return _scoreLevelBoundsCollection.ScoreLevels.OrderBy(o => o.UpperBound).ElementAt(_scoreLevelBoundsCollection.ScoreLevels.ToList().Count / 2);
                }
                throw new ScoreException("Unable to determine Score");
            }
            return foundItem;
        }
    }
}
