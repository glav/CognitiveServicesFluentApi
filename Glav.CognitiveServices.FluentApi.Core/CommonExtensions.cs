using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.Core
{
    /// <summary>
    /// Common set of extensions and helpers across all fluent API services.
    /// </summary>
    public static class CommonExtensions
    {
        public static ScoreLevelBoundsDefinition Score<T>(this BaseApiAnalysisContext<T> context, double scoreValue) where T : IApiCallResult
        {
            return context.ScoringEngine.EvaluateScore(scoreValue);
        }

    }
}
