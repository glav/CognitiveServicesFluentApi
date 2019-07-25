using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.Core
{
    /// <summary>
    /// Common set of extensions and helpers across all fluent API services.
    /// </summary>
    public static class CommonExtensions
    {
        /// <summary>
        /// Evaluate the score or confidence level value using the scoring engine of the API being used.
        /// </summary>
        /// <param name="context">API Context</param>
        /// <param name="scoreValue">The value to parse</param>
        /// <returns></returns>
        public static ScoreLevelBoundsDefinition Score<T>(this BaseApiAnalysisContext<T> context, double scoreValue) where T : IApiCallResult
        {
            return context.ScoringEngine.EvaluateScore(scoreValue);
        }

    }
}
