using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroup
{
    public class LargePersonGroupCreateAnalysisContext : BaseApiAnalysisContext<LargePersonGroupCreateResult, BaseApiErrorResponse, double> 
    {
        public LargePersonGroupCreateAnalysisContext(ApiActionDataCollection actionData, LargePersonGroupCreateResult analysisResult)
            : base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public LargePersonGroupCreateAnalysisContext(ApiActionDataCollection actionData)
            : base(actionData, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public override ApiActionDefinition AnalysisType => FaceApiOperations.LargePersonGroupCreate;

        public override IEnumerable<BaseApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }


    }
}
