using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public static class SentimentAnalysisContextExtensions
    {
        public static ScoreLevelBoundsDefinition Score(this TextAnalyticAnalysisResults results, SentimentResultResponseItem responseItem)
        {
            return results.AnalysisSettings.ConfigurationSettings.ScoringEngine.EvaluateScore(responseItem.score);
        }


        public static int NumberOfResponses(this TextAnalyticAnalysisResults results, string sentimentClassification)
        {
            return results.SentimentAnalysis.AnalysisResult.ResponseData.documents.Count(d => Score(results, d).CanonicalName == sentimentClassification.ToLowerInvariant());   
        }

        public static SentimentResultResponseItem GetResult(this TextAnalyticAnalysisResults results, long id)
        {
            return results.SentimentAnalysis.AnalysisResult.ResponseData.documents.FirstOrDefault(a => a.id == id);
        }

        public static IEnumerable<SentimentResultResponseItem> GetResults(this TextAnalyticAnalysisResults results)
        {
            return results.SentimentAnalysis.AnalysisResult.ResponseData.documents.AsEnumerable();
        }

        public static IEnumerable<SentimentResultResponseItem> GetResults(this TextAnalyticAnalysisResults results, string sentimentClassification)
        {
            return results.SentimentAnalysis.AnalysisResult.ResponseData.documents.Where(d => Score(results, d).CanonicalName == sentimentClassification.ToLowerInvariant());
        }

        private static bool IsContextResponseDataNull(SentimentAnalysisContext context)
        {
            return (context == null || context.AnalysisResult == null || context.AnalysisResult.ResponseData == null || context.AnalysisResult.ResponseData.documents == null);

        }
    }
}
