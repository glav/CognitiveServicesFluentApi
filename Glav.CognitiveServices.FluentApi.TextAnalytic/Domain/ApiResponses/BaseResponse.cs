using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses
{
    public abstract class BaseResponse<T> where T : class
    {
        public long id { get; set; }

        public T[] documents { get; set; }

        public ApiErrorResponse[] errors { get; set; }
    }
}
