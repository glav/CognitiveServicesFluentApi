using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System.Collections.Generic;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonFaceDeleteAnalysisContext : BaseApiAnalysisContext<LargePersonGroupPersonFaceDeleteResult, BaseApiErrorResponse, double> 
    {
        public LargePersonGroupPersonFaceDeleteAnalysisContext(ApiActionDataCollection actionData, LargePersonGroupPersonFaceDeleteResult analysisResult)
            : base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public LargePersonGroupPersonFaceDeleteAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine<double> scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionDefinition AnalysisType => FaceApiOperations.LargePersonGroupPersonFaceDelete;

        public override IEnumerable<BaseApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }


    }
}
