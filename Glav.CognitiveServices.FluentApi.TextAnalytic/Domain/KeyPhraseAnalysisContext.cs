using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public class KeyPhraseAnalysisContext : BaseApiAnalysisContext<TextAnalyticActionData, KeyPhraseResult>
    {
        public KeyPhraseAnalysisContext(TextAnalyticActionData actionData, KeyPhraseResult analysisResult, IScoreEvaluationEngine scoringEngine)
            :base(actionData, analysisResult, scoringEngine)
        {
        }
        public override ApiActionType AnalysisType { get { return ApiActionType.TextAnalyticsKeyphrases; } }

    }
}
