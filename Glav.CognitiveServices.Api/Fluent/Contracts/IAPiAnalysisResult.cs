﻿using Glav.CognitiveServices.Api.Fluent.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.Contracts
{
    public interface IApiAnalysisResult<T> : IApiCallResult where T : IActionResponseRoot
    {

        T ResponseData { get;  }

    }

}
