using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses
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
