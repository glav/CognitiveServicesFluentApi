using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public class LanguageAnalysisContext : IApiAnalysisContext<TextAnalyticActionData, LanguagesResult>
    {
        public LanguageAnalysisContext(TextAnalyticActionData actionData, LanguagesResult analysisResult, IScoreEvaluationEngine scoringEngine)
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
            ScoringEngine = scoringEngine;
        }
        public ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsLanguages; } }

        public TextAnalyticActionData AnalysisInput { get; private set; }

        public LanguagesResult AnalysisResult { get; private set; }

        public IScoreEvaluationEngine ScoringEngine { get; private set; }
    }
}
