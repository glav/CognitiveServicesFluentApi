using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class OcrAnalysisContext : BaseApiAnalysisContext<OcrAnalysisResult> 
    {
        public OcrAnalysisContext(ApiActionDataCollection actionData, OcrAnalysisResult analysisResult, IScoreEvaluationEngine scoringEngine)
            : base(actionData, analysisResult, scoringEngine)
        {
        }
        public OcrAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionType AnalysisType => ApiActionType.ComputerVisionOcrAnalysis;

    }
}
