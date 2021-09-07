using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class OcrAnalysisContext : BaseApiAnalysisContext<OcrAnalysisResult, RequestIdErrorResponse, double> 
    {
        public OcrAnalysisContext(ApiActionDataCollection actionData, OcrAnalysisResult analysisResult)
            : base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public OcrAnalysisContext(ApiActionDataCollection actionData)
            : base(actionData, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public override ApiActionDefinition AnalysisType => ComputerVisionApiOperations.OcrAnalysis;

        public override IEnumerable<RequestIdErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }

    }
}
