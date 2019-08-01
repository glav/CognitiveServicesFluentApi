using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public class KeyPhraseAnalysisContext : BaseApiAnalysisContext<KeyPhraseResult>
    {
        public KeyPhraseAnalysisContext(ApiActionDataCollection actionData, KeyPhraseResult analysisResult, IScoreEvaluationEngine scoringEngine)
            :base(actionData, analysisResult, scoringEngine)
        {
        }
        public override ApiActionDefinition AnalysisType { get { return TextAnalyticApiOperations.KeyPhraseAnalysis; } }

    }
}
