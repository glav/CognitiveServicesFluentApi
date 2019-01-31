using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class LargePersonGroupCreateAnalysisContext : BaseApiAnalysisContext<LargePersonGroupCreateResult> 
    {
        public LargePersonGroupCreateAnalysisContext(ApiActionDataCollection actionData, LargePersonGroupCreateResult analysisResult, IScoreEvaluationEngine scoringEngine)
            : base(actionData, analysisResult, scoringEngine)
        {
        }
        public LargePersonGroupCreateAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionType AnalysisType => ApiActionType.FaceLargePersonGroupCreate;

    }
}
