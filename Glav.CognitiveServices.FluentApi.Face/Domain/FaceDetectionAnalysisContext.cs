using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class FaceDetectionAnalysisContext : BaseApiAnalysisContext<FaceDetectionResult, BaseApiErrorResponse> 
    {
        public FaceDetectionAnalysisContext(ApiActionDataCollection actionData, FaceDetectionResult analysisResult, IScoreEvaluationEngine scoringEngine)
            : base(actionData, analysisResult, scoringEngine)
        {
        }
        public FaceDetectionAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionDefinition AnalysisType => FaceApiOperations.FaceDetection;

        public override IEnumerable<BaseApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }
    }
}
