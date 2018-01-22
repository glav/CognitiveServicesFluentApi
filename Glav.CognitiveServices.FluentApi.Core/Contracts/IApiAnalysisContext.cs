using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IApiAnalysisContext<TData, TResult> where TData : IApiActionData
                                                    where TResult : IApiCallResult
    {
        ApiActionType AnalysisType { get; }
        TData AnalysisInput { get; }

        TResult AnalysisResult { get; }

        IScoreEvaluationEngine ScoringEngine { get; }
    }

    public abstract class BaseApiAnalysisContext<TData, TResult> where TData : IApiActionData
                                                    where TResult : IApiCallResult
    {
        public BaseApiAnalysisContext(TData actionData, TResult analysisResult, IScoreEvaluationEngine scoringEngine)
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
            ScoringEngine = scoringEngine;
        }

        public abstract ApiActionType AnalysisType { get; }
        public virtual TData AnalysisInput { get; protected set; }

        public virtual TResult AnalysisResult { get; protected set; }

        public IScoreEvaluationEngine ScoringEngine { get; private set; }

        public void SetScoringEngine(IScoreEvaluationEngine scoreEngine)
        {
            if (scoreEngine == null)
            {
                throw new CognitiveServicesArgumentException("ScoreEvaluationEngine cannot be NULL");
            }
            ScoringEngine = scoreEngine;
        }
    }
}
