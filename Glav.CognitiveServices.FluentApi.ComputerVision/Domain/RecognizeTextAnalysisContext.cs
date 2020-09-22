using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.Core.Operations;
using System.Collections.Generic;
using System.Linq;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class RecognizeTextAnalysisContext : BaseApiAnalysisContext<RecognizeTextAnalysisResult, RequestIdErrorResponse> 
    {
        public RecognizeTextAnalysisContext(ApiActionDataCollection actionData, RecognizeTextAnalysisResult analysisResult, IScoreEvaluationEngine scoringEngine)
            : base(actionData, analysisResult, scoringEngine)
        {
        }
        public RecognizeTextAnalysisContext(ApiActionDataCollection actionData, IScoreEvaluationEngine scoringEngine)
            : base(actionData, scoringEngine)
        {
        }
        public override ApiActionDefinition AnalysisType => ComputerVisionApiOperations.RecognizeText;

        public override IEnumerable<RequestIdErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }


    }
}
