namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public interface IScoreEvaluationEngine
    {
        ScoreLevelBoundsDefinition EvaluateScore(double score);

        IScoreLevelBoundsCollection ScoreLevels { get; }
    }
}