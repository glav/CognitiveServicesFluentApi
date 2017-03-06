using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses
{
    public abstract class TextAnalyticBaseResponse<T> where T : class
    {
        public long id { get; set; }

        public T[] documents { get; set; }

        public TextAnalyticApiError[] errors { get; set; }
    }
}
