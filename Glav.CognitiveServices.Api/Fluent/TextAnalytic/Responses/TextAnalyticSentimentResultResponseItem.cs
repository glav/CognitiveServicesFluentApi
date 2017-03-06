using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses
{
    public sealed class TextAnalyticSentimentResultResponseItem
    {
        public long id { get; set; }
        
        public double score { get; set; }

        public SentimentClassification SentimentClassification
        {
            get
            {
                if (score <= 0.35)
                {
                    return SentimentClassification.Negative;
                }
                if (score > 0.35 && score < 0.45)
                {
                    return SentimentClassification.SlightlyNegative;
                }
                if (score >= 0.45 && score <= 0.55)
                {
                    return SentimentClassification.Neutral;
                }
                if (score >0.55 && score <= 0.75)
                {
                    return SentimentClassification.SlightlyPositive;
                }
                return SentimentClassification.Positive;
            }
        }
    }
}
