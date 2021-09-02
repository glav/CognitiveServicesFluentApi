using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public class SentimentAnalysisContext : BaseApiAnalysisContext<SentimentResult, ApiErrorResponse, SentimentResultResponseItem>
    {
        public SentimentAnalysisContext(ApiActionDataCollection actionData, SentimentResult analysisResult)
            : base(actionData, analysisResult, new SentimentCustomScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public override ApiActionDefinition AnalysisType { get { return TextAnalyticApiOperations.SentimentAnalysis; } }

        public override IEnumerable<ApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.SelectMany(e => e.ResponseData?.errors);
        }

    }
}
