using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class FaceDetectionAnalysisContext : BaseApiAnalysisContext<FaceDetectionResult> 
    {
        public FaceDetectionAnalysisContext(ApiActionDataCollection actionData, FaceDetectionResult analysisResult, IScoreEvaluationEngine scoringEngine)
            : base(actionData, analysisResult, scoringEngine)
        {
        }
        public FaceDetectionAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionType AnalysisType => ApiActionType.FaceDetection;

    }
}
