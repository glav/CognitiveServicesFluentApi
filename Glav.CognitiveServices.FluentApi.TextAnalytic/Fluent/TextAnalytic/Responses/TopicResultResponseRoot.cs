using Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.TextAnalytic.Responses
{
    public sealed class TopicResultResponseRoot : IActionResponseRoot
    {
        public string code { get; set; }
        public string message { get; set; }
        public TopicErrorItem innerError { get; set; }
    }

    public sealed class TopicErrorItem
    {
        public string code { get; set; }
        public string message { get; set; }
        public int minimumNumberOfDocuments { get; set; }

    }
}
