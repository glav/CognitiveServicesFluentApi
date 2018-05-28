using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    //public interface IApiAnalysisContext<TData, TResult> where TData : IApiActionDataCollection
    //                                                where TResult : IApiCallResult
    //{
    //    ApiActionType AnalysisType { get; }
    //    TData AnalysisInput { get; }

    //    TResult AnalysisResult { get; }

    //    IScoreEvaluationEngine ScoringEngine { get; }
    //}

    public abstract class BaseApiAnalysisContext<TResult> where TResult : IApiCallResult
    {
        public BaseApiAnalysisContext(ApiActionDataCollection actionData, TResult analysisResult, IScoreEvaluationEngine scoringEngine)
        {
            AnalysisInput = actionData;
            AnalysisResults = new List<TResult> { analysisResult };
            ScoringEngine = scoringEngine;
        }

        public abstract ApiActionType AnalysisType { get; }
        public virtual ApiActionDataCollection AnalysisInput { get; protected set; }

        /// <summary>
        /// Contains results from multiple calls to an API. This contains at least 1 result. Where batching is
        /// supported, this will contain 1 result of an API call, but multiple individual processing results within that
        /// as a result of batch processing such as the case with TextAnalytics. Where batching is not supported, this
        /// will contain at least 1 result but potentially more depending on how many API actions are specified, which
        /// will translate into how many API calls are actually made. Each call is then stored here as a separate item with
        /// separate API call results. ComputerVision is an example where a separate API call is made per action.
        /// </summary>
        public virtual IEnumerable<TResult> AnalysisResults { get; protected set; }

        /// <summary>
        /// A convenience property that returns the first, singular result from the <see cref="AnalysisResults" property./>
        /// </summary>
        public virtual TResult AnalysisResult { get { return AnalysisResults.FirstOrDefault(); }  }

        public IScoreEvaluationEngine ScoringEngine { get; private set; }

        public void SetScoringEngine(IScoreEvaluationEngine scoreEngine)
        {
            ScoringEngine = scoreEngine ?? throw new CognitiveServicesArgumentException("ScoreEvaluationEngine cannot be NULL");
        }
    }
}
