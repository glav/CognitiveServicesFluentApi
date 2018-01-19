using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public class SentimentAnalysisContext : IApiAnalysisContext<TextAnalyticActionData, SentimentResult>
    {
        public SentimentAnalysisContext(TextAnalyticActionData actionData, SentimentResult analysisResult, IScoreEvaluationEngine scoringEngine)
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
            ScoringEngine = scoringEngine;
        }
        public ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsSentiment; } }

        public TextAnalyticActionData AnalysisInput { get; private set; }

        public SentimentResult AnalysisResult { get; private set; }

        public IScoreEvaluationEngine ScoringEngine { get; private set; }
    }
}
