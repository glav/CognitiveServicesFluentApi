using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses;

namespace Glav.CognitiveServices.Api.Fluent
{
    public static class SentimentAnalysisContextExtensions
    {
        public static int NumberOfResponses(this SentimentAnalysisContext context, SentimentClassification classification)
        {
            if (IsContextResponseDataNull(context))
            {
                return 0;
            }

            return context.AnalysisResult.ResponseData.documents.Count(a => a.SentimentClassification == classification);
        }

        public static SentimentResultResponseItem GetResult(this SentimentAnalysisContext context, long id)
        {
            if (IsContextResponseDataNull(context))
            {
                return null;
            }

            return context.AnalysisResult.ResponseData.documents.FirstOrDefault(a => a.id == id);
        }

        public static IEnumerable<SentimentResultResponseItem> GetResults(this SentimentAnalysisContext context)
        {
            if (IsContextResponseDataNull(context))
            {
                return null;
            }

            return context.AnalysisResult.ResponseData.documents.AsEnumerable();
        }

        public static IEnumerable<SentimentResultResponseItem> GetResults(this SentimentAnalysisContext context, SentimentClassification classification)
        {
            if (IsContextResponseDataNull(context))
            {
                return null;
            }

            return context.AnalysisResult.ResponseData.documents.Where(a => a.SentimentClassification == classification);
        }

        private static bool IsContextResponseDataNull(SentimentAnalysisContext context)
        {
            return (context == null || context.AnalysisResult == null || context.AnalysisResult.ResponseData == null || context.AnalysisResult.ResponseData.documents == null);

        }
    }
}
