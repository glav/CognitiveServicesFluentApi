﻿using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;
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
            return context.ScoringEngine.Evaluate(responseItem);
        }

        public static int NumberOfResponses(this SentimentAnalysisContext context, string sentimentClassification)
        {
            return context.AnalysisResult.ResponseData.documents.Count(d => Score(context, d).NormalisedName == sentimentClassification.ToLowerInvariant());   
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
            return context.AnalysisResult.ResponseData.documents.Where(d => Score(context, d).NormalisedName == sentimentClassification.ToLowerInvariant());
        }

        public static TextAnalyticAnalysisSettings AddSentimentAnalysisSplitIntoSentences(this TextAnalyticAnalysisSettings apiAnalysis, string textToAnalyse)
        {
            var sentences = textToAnalyse.SplitTextIntoSentences();
            var actionData = apiAnalysis.GetOrCreateActionDataInstance<TextAnalyticActionData>(TextAnalyticApiOperations.SentimentAnalysis);
            sentences.ToList().ForEach(s =>
            {
                actionData.Add(TextAnalyticApiOperations.SentimentAnalysis, s);

            });
            return apiAnalysis;
        }


        public static string GetInitialErrorMessage(this SentimentAnalysisContext context)
        {
            var message = context.AnalysisResult.ResponseData.errors != null ? 
                context.AnalysisResult.ResponseData.errors.First().message : 
                context.AnalysisResult.ApiCallResult.Data;
            return message;
        }

    }
}
