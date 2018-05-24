using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public class SentimentAnalysisContext : BaseApiAnalysisContext<SentimentResult>
    {
        public SentimentAnalysisContext(ApiActionDataCollection actionData, SentimentResult analysisResult, IScoreEvaluationEngine scoringEngine)
            : base(actionData, analysisResult, scoringEngine)
        {
        }
        public override ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsSentiment; } }

    }
}
