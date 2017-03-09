using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses
{
    public sealed class LanguagesResultResponseItem
    {
        public long id { get; set; }
        public DetectedLanguage[] detectedLanguages { get; set; }

    }

    public sealed class DetectedLanguage
    {
        public string name { get; set; }
        public string iso6391name { get; set; }
        public double score { get; set; }
    }

}
