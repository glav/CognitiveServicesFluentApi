using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses
{
    public sealed class SentimentResultResponseItem
    {
        public long id { get; set; }
        
        public double score { get; set; }

    }
}
