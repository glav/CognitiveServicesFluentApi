using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupTrainStartAnalysisContext : BaseApiAnalysisContext<LargePersonGroupTrainStartResult, BaseApiErrorResponse> 
    {
        public LargePersonGroupTrainStartAnalysisContext(ApiActionDataCollection actionData, LargePersonGroupTrainStartResult analysisResult, IScoreEvaluationEngine scoringEngine)
            : base(actionData, analysisResult, scoringEngine)
        {
        }
        public LargePersonGroupTrainStartAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionDefinition AnalysisType => FaceApiOperations.LargePersonGroupTrainStart;

        public override IEnumerable<BaseApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }


    }
}
