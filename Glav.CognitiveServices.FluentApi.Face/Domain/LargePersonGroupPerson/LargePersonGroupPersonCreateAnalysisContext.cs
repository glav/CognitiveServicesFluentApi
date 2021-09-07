using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonCreateAnalysisContext : BaseApiAnalysisContext<LargePersonGroupPersonCreateResult, BaseApiErrorResponse, double> 
    {
        public LargePersonGroupPersonCreateAnalysisContext(ApiActionDataCollection actionData, LargePersonGroupPersonCreateResult analysisResult)
            : base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public LargePersonGroupPersonCreateAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine<double> scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionDefinition AnalysisType => FaceApiOperations.LargePersonGroupPersonCreate;

        public override IEnumerable<BaseApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }


    }
}
