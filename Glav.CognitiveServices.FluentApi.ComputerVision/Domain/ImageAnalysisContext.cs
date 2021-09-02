using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class ImageAnalysisContext : BaseApiAnalysisContext<ImageAnalysisResult, RequestIdErrorResponse, double> 
    {
        public ImageAnalysisContext(ApiActionDataCollection actionData, ImageAnalysisResult analysisResult)
            : base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public ImageAnalysisContext(ApiActionDataCollection actionData)
            : base(actionData, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public override ApiActionDefinition AnalysisType => ComputerVisionApiOperations.ImageAnalysis;

        public override IEnumerable<RequestIdErrorResponse> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData.error);
        }
    }
}
