﻿using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IApiAnalysisResult<T> : IApiCallResult where T : IActionResponseRoot
    {
        T ResponseData { get;  }

    }

}
