using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public class KeyPhraseAnalysisContext : IApiAnalysisContext<TextAnalyticActionData, KeyPhraseResult>
    {
        public KeyPhraseAnalysisContext(TextAnalyticActionData actionData, KeyPhraseResult analysisResult, IScoreEvaluationEngine scoringEngine)
        {
            AnalysisInput = actionData;
            AnalysisResult = analysisResult;
            ScoringEngine = scoringEngine;
        }
        public ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsKeyphrases; } }

        public TextAnalyticActionData AnalysisInput { get; private set; }

        public KeyPhraseResult AnalysisResult { get; private set; }

        public IScoreEvaluationEngine ScoringEngine { get; private set;}
    }
}
