using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public class SentimentAnalysisContext : BaseApiAnalysisContext<SentimentResult, ApiErrorResponse[]>
    {
        public SentimentAnalysisContext(ApiActionDataCollection actionData, SentimentResult analysisResult, IScoreEvaluationEngine scoringEngine)
            : base(actionData, analysisResult, scoringEngine)
        {
        }
        public override ApiActionDefinition AnalysisType { get { return TextAnalyticApiOperations.SentimentAnalysis; } }

        public override IEnumerable<ApiErrorResponse[]> GetAllErrors()
        {
            return AnalysisResults.Select(e => e.ResponseData?.errors);
        }

    }
}
