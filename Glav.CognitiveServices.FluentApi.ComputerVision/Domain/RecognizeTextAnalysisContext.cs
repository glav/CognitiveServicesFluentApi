using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.Core.Operations;
using System.Collections.Generic;
using System.Linq;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class RecognizeTextAnalysisContext : BaseApiAnalysisContext<RecognizeTextAnalysisResult, RequestIdErrorResponse, double> 
    {
        public RecognizeTextAnalysisContext(ApiActionDataCollection actionData, RecognizeTextAnalysisResult analysisResult)
            : base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public RecognizeTextAnalysisContext(ApiActionDataCollection actionData)
            : base(actionData, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public override ApiActionDefinition AnalysisType => ComputerVisionApiOperations.RecognizeText;

        public override IEnumerable<RequestIdErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }


    }
}
