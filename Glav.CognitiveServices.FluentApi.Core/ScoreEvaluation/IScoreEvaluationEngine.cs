namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public interface IScoreEvaluationEngine<T>
    {
        ScoreLevelBoundsDefinition Evaluate(T item);
        IScoreLevelBoundsCollection ScoreLevels { get; }
    }
}