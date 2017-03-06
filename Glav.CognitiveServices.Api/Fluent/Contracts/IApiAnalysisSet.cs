using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.Contracts
{
    public interface IApiAnalysisSet<TData,TResult> where TData : IApiAction
                                                    where TResult : IApiAnalysisResult
    {
        ApiActionType AnalysisType { get; }
        TData AnalysisInput { get; }

        TResult AnalysisResult { get; }
    }
}
