using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses
{
    public sealed class SentimentResultResponseItem : SentimentClassAndConfidence
    {
        public long id { get; set; }
        
        public Sentences[] sentences { get; set; }
    }

    public class ConfidenceScores
    {
        public double positive { get; set; }
        public double neutral { get; set; }
        public double negative { get; set; }
    }

    public class SentimentClassAndConfidence
    {
        public string sentiment { get; set; }
        public ConfidenceScores confidenceScores { get; set; }

    }

    public class Sentences : SentimentClassAndConfidence
    {
        public long offset { get; set; }
        public long length { get; set; }
        public string text { get; set; }
    }

}
