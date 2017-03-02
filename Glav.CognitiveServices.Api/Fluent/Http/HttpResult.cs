using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.Http
{
    internal sealed class HttpResult
    {
        private HttpResult()
        {

        }
        public bool Successfull { get; private set; }

        public string ErrorMessage { get; private set; }

        public string Data { get; private set; }

        public static HttpResult Success(string result)
        {
            return new HttpResult { Successfull = true, Data = result };
        }

        public static HttpResult Fail(string errorMessage)
        {
            return new HttpResult { Successfull = false, ErrorMessage = errorMessage };
        }

    }
}
