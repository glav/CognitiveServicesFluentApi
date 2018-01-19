using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public static class LanguageAnalysisContextExtensions
    {
        public static ScoreLevelBoundsDefinition Score(this LanguageAnalysisContext context, DetectedLanguage languageResult)
        {
            return context.ScoringEngine.EvaluateScore(languageResult.score);
        }

        public static int NumberOfResponses(this LanguageAnalysisContext context, string languageConfidence)
        {
            var allLangResults = context.AnalysisResult.ResponseData.documents.SelectMany(d => d.detectedLanguages);
            return allLangResults.Count(d => Score(context, d).Name == languageConfidence);
        }

        public static LanguagesResultResponseItem GetResult(this LanguageAnalysisContext context, long id)
        {
            return context.AnalysisResult.ResponseData.documents.FirstOrDefault(a => a.id == id);
        }
        
        public static IEnumerable<LanguagesResultResponseItem> GetResults(this LanguageAnalysisContext context)
        {
            return context.AnalysisResult.ResponseData.documents.AsEnumerable();
        }

        public static IEnumerable<LanguagesResultResponseItem> GetResultsThatContainConfidenceLevel(this LanguageAnalysisContext context, string languageConfidence)
        {
            var results = new List<LanguagesResultResponseItem>();
            context.AnalysisResult.ResponseData.documents.ToList().ForEach((item) =>
            {
                if (item.detectedLanguages.Any(i => Score(context,i).CanonicalName == languageConfidence)
                    && !results.Any(i => i.id == item.id))
                {
                    results.Add(item);
                }
            });
            return results;
        }

        private static bool IsContextResponseDataNull(LanguageAnalysisContext context)
        {
            return (context == null || context.AnalysisResult == null || context.AnalysisResult.ResponseData == null || context.AnalysisResult.ResponseData.documents == null);

        }
    }
}
