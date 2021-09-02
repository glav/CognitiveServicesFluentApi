using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Face.Domain
{
    public class FaceDetectionAnalysisContext : BaseApiAnalysisContext<FaceDetectionResult, BaseApiErrorResponse, double> 
    {
        public FaceDetectionAnalysisContext(ApiActionDataCollection actionData, FaceDetectionResult analysisResult)
            : base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public FaceDetectionAnalysisContext(ApiActionDataCollection actionData)
            : base(actionData, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public override ApiActionDefinition AnalysisType => FaceApiOperations.FaceDetection;

        public override IEnumerable<BaseApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }
    }
}
