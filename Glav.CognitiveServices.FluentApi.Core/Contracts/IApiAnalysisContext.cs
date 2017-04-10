using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IApiAnalysisContext<TData,TResult> where TData : IApiActionData
                                                    where TResult : IApiCallResult
    {
        ApiActionType AnalysisType { get; }
        TData AnalysisInput { get; }

        TResult AnalysisResult { get; }
    }
}
