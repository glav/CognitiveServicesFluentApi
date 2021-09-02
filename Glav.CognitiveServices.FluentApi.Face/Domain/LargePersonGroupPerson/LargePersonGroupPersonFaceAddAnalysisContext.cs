using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonFaceAddAnalysisContext : BaseApiAnalysisContext<LargePersonGroupPersonFaceAddResult, BaseApiErrorResponse, double> 
    {
        public LargePersonGroupPersonFaceAddAnalysisContext(ApiActionDataCollection actionData, LargePersonGroupPersonFaceAddResult analysisResult)
            : base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public LargePersonGroupPersonFaceAddAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine<double> scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionDefinition AnalysisType => FaceApiOperations.LargePersonGroupPersonFaceAdd;

        public override IEnumerable<BaseApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }


    }
}
