using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.Contracts
{
    public interface IApiAnalysisResult
    {
        long Id { get;  }
        IApiAction ActionPerformed { get; }
        T ActionResult<T>() where T : class, IApiAnalysisResultData;
    }
}
