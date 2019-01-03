using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public static class KeyPhraseAnalysisContextExtensions
    {
        public static ScoreLevelBoundsDefinition Score(this KeyPhraseAnalysisContext context, SentimentResultResponseItem responseItem)
        {
            return context.ScoringEngine.EvaluateScore(responseItem.score);
        }
        public static ScoreLevelBoundsDefinition Score(this KeyPhraseAnalysisContext context, double scoreValue)
        {
            return context.ScoringEngine.EvaluateScore(scoreValue);
        }


        public static IEnumerable<KeyPhraseResultResponseItem> GetResults(this KeyPhraseAnalysisContext context)
        {
            return context.AnalysisResult.ResponseData.documents.AsEnumerable();
        }

    }
}
