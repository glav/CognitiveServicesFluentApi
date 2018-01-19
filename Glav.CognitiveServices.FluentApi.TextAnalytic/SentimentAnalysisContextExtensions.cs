using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public static class SentimentAnalysisContextExtensions
    {
        public static ScoreLevelBoundsDefinition Score(this SentimentAnalysisContext context, SentimentResultResponseItem responseItem)
        {
            return context.ScoringEngine.EvaluateScore(responseItem.score);
        }


        public static int NumberOfResponses(this SentimentAnalysisContext context, string sentimentClassification)
        {
            return context.AnalysisResult.ResponseData.documents.Count(d => Score(context, d).CanonicalName == sentimentClassification.ToLowerInvariant());   
        }

        public static SentimentResultResponseItem GetResult(this SentimentAnalysisContext context, long id)
        {
            return context.AnalysisResult.ResponseData.documents.FirstOrDefault(a => a.id == id);
        }

        public static IEnumerable<SentimentResultResponseItem> GetResults(this SentimentAnalysisContext context)
        {
            return context.AnalysisResult.ResponseData.documents.AsEnumerable();
        }

        public static IEnumerable<SentimentResultResponseItem> GetResults(this SentimentAnalysisContext context, string sentimentClassification)
        {
            return context.AnalysisResult.ResponseData.documents.Where(d => Score(context, d).CanonicalName == sentimentClassification.ToLowerInvariant());
        }

        private static bool IsContextResponseDataNull(SentimentAnalysisContext context)
        {
            return (context == null || context.AnalysisResult == null || context.AnalysisResult.ResponseData == null || context.AnalysisResult.ResponseData.documents == null);

        }
    }
}
