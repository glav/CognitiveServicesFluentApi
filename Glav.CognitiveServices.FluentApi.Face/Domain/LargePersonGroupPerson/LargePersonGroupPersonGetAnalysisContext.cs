using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System.Collections.Generic;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Face.Domain.LargePersonGroupPerson
{
    public class LargePersonGroupPersonGetAnalysisContext : BaseApiAnalysisContext<LargePersonGroupPersonGetResult, BaseApiErrorResponse, double> 
    {
        public LargePersonGroupPersonGetAnalysisContext(ApiActionDataCollection actionData, LargePersonGroupPersonGetResult analysisResult)
            : base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public LargePersonGroupPersonGetAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine<double> scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionDefinition AnalysisType => FaceApiOperations.LargePersonGroupPersonGet;

        public override IEnumerable<BaseApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }


    }
}
