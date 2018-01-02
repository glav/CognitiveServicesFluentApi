namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public interface IScoreLevelBoundsDefinition
    {
        double LowerBound { get; }
        string Name { get; }
        double UpperBound { get; }
    }
}