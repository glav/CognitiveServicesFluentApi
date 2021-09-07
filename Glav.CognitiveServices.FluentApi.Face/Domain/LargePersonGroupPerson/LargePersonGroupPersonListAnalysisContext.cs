using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonListAnalysisContext : BaseApiAnalysisContext<LargePersonGroupPersonListResult, BaseApiErrorResponse, double> 
    {
        public LargePersonGroupPersonListAnalysisContext(ApiActionDataCollection actionData, LargePersonGroupPersonListResult analysisResult)
            : base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public LargePersonGroupPersonListAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine<double> scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionDefinition AnalysisType => FaceApiOperations.LargePersonGroupPersonList;

        public override IEnumerable<BaseApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }


    }
}
