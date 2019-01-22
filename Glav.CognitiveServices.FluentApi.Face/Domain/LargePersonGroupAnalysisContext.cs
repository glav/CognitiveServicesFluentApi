﻿using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class LargePersonGroupAnalysisContext : BaseApiAnalysisContext<LargePersonGroupCreateResult> 
    {
        public LargePersonGroupAnalysisContext(ApiActionDataCollection actionData, LargePersonGroupCreateResult analysisResult, IScoreEvaluationEngine scoringEngine)
            : base(actionData, analysisResult, scoringEngine)
        {
        }
        public LargePersonGroupAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionType AnalysisType => ApiActionType.FaceLargePersonGroups;

    }
}
