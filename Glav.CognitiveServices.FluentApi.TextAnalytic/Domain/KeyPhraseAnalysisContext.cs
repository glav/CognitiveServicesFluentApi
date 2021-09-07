using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public class KeyPhraseAnalysisContext : BaseApiAnalysisContext<KeyPhraseResult, ApiErrorResponse, double>
    {
        public KeyPhraseAnalysisContext(ApiActionDataCollection actionData, KeyPhraseResult analysisResult)
            :base(actionData, analysisResult, new NumericScoreEvaluationEngine(new DefaultScoreLevels()))
        {
        }
        public override ApiActionDefinition AnalysisType { get { return TextAnalyticApiOperations.KeyPhraseAnalysis; } }

        public override IEnumerable<ApiErrorResponse> GetAllErrors()
        {
            return AnalysisResults.SelectMany(e => e.ResponseData?.errors);
        }

    }
}
