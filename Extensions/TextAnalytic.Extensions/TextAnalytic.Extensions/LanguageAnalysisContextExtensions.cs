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
        public static ScoreLevelBoundsDefinition Score(this LanguageAnalysisContext context, double scoreValue)
        {
            return context.ScoringEngine.EvaluateScore(scoreValue);
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

        /// <summary>
        /// Find any results that match the textual descriptor of the Score level. eg. Find all results matching have a score of 'Positive'
        /// </summary>
        /// <param name="context"></param>
        /// <param name="languageConfidenceDescriptor"></param>
        /// <returns></returns>
        public static IEnumerable<LanguagesResultResponseItem> GetResultsThatContainConfidenceLevel(this LanguageAnalysisContext context, string languageConfidenceDescriptor)
        {
            var results = new List<LanguagesResultResponseItem>();
            if (string.IsNullOrWhiteSpace(languageConfidenceDescriptor))
            {
                return results;
            }

            var normalisedLevel = languageConfidenceDescriptor.ToLowerInvariant();
            context.AnalysisResult.ResponseData.documents.ToList().ForEach((item) =>
            {
                if (item.detectedLanguages.Any(i => Score(context,i).NormalisedName == normalisedLevel)
                    && !results.Any(i => i.id == item.id))
                {
                    results.Add(item);
                }
            });
            return results;
        }

        public static string GetInitialErrorMessage(this LanguageAnalysisContext context)
        {
            var message = context.AnalysisResult.ResponseData.errors != null ?
                context.AnalysisResult.ResponseData.errors.First().message :
                context.AnalysisResult.ApiCallResult.Data;
            return message;
        }

    }
}
