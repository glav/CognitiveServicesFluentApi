using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
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

        public static IEnumerable<KeyPhraseResultResponseItem> GetResults(this KeyPhraseAnalysisContext context)
        {
            return context.AnalysisResult.ResponseData.documents.AsEnumerable();
        }

        public static IEnumerable<string> GetAllKeyPhrases(this KeyPhraseAnalysisContext context)
        {
            return context.GetResults().SelectMany(r => r.keyPhrases);
        }

        public static TextAnalyticAnalysisSettings AddKeyPhraseAnalysisSplitIntoSentences(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            var sentences = textToAnalyse.SplitTextIntoSentences();
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<TextAnalyticActionData>(TextAnalyticApiOperations.KeyPhraseAnalysis);
            sentences.ToList().ForEach(s =>
            {
                actionData.Add(TextAnalyticApiOperations.KeyPhraseAnalysis, s);
            });
            return apiAnalysis;
        }


        public static string GetInitialErrorMessage(this KeyPhraseAnalysisContext context)
        {
            var message = context.AnalysisResult.ResponseData.errors != null ?
                context.AnalysisResult.ResponseData.errors.First().message :
                context.AnalysisResult.ApiCallResult.Data;
            return message;
        }


    }
}
