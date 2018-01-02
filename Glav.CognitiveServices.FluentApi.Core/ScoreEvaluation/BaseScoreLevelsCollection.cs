using System;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public abstract class BaseScoreLevelsCollection : IScoreLevelBoundsCollection
    {
        private readonly SortedList<double, ScoreLevelBoundsDefinition> _scoreLevels = new SortedList<double, ScoreLevelBoundsDefinition>();

        public IEnumerable<ScoreLevelBoundsDefinition> ScoreLevels { get; private set; }

        public void AddScoreLevelDefinition(ScoreLevelBoundsDefinition scoreLevel)
        {
            ValidateLevel(scoreLevel);
            _scoreLevels.Add(scoreLevel.LowerBound, scoreLevel);
        }

        private void ValidateLevel(ScoreLevelBoundsDefinition scoreLevel)
        {
            var areBoundsAlreadyUsed = _scoreLevels.Any(s => s.Value.LowerBound == scoreLevel.LowerBound || s.Value.UpperBound == scoreLevel.UpperBound);
            if (areBoundsAlreadyUsed)
            {
                throw new ArgumentException("The Lower or Upper bounds value are already defined.");
            }
        }

        public void ValidateScoreLevelList()
        {
            if (_scoreLevels.ElementAt(0).Value.LowerBound != 0 || _scoreLevels.ElementAt(_scoreLevels.Count - 1).Value.UpperBound != 1)
            {
                throw new Exception("List is not valid. Does not cover all values between 0 and 1");
            }

            if (_scoreLevels.Count > 1)
            {
                for (var itemCnt = 0; itemCnt < _scoreLevels.Count - 1; itemCnt++) // exclude the last item
                {
                    var currentScoreItem = _scoreLevels.ElementAt(itemCnt).Value;
                    var nextScoreItem = _scoreLevels.ElementAt(itemCnt).Value;
                    if (currentScoreItem.UpperBound != nextScoreItem.LowerBound)
                    {
                        throw new ArgumentException("Previous score level upper bound value must match next score level lower bound value.");
                    }
                }
            }

        }
    }

}
