using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public interface IScoreLevelBoundsCollection
    {
        IEnumerable<ScoreLevelBoundsDefinition> ScoreLevels { get; }
    }
}