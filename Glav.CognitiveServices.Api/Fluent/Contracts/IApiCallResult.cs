using Glav.CognitiveServices.Api.Fluent.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.Contracts
{
    public interface IApiCallResult
    {
        bool Successfull { get; }
        HttpResult ApiCallResult { get; }
    }
}
