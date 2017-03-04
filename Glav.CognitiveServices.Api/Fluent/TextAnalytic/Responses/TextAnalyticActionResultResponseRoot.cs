using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses
{
    public sealed class TextAnalyticActionResultResponseRoot : IActionResponseRoot
    {
        public TextAnalyticActionResultResponseItem[] documents { get; set; }
        public string[] errors { get; set; }
    }
}
