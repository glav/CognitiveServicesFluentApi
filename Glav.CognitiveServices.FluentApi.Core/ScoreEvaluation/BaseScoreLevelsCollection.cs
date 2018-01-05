using System;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public abstract class BaseScoreLevelsCollection : IScoreLevelBoundsCollection
    {
        private readonly SortedList<double, ScoreLevelBoundsDefinition> _scoreLevels = new SortedList<double, ScoreLevelBoundsDefinition>();

        public IEnumerable<ScoreLevelBoundsDefinition> ScoreLevels { get { return _scoreLevels.Values; }  }

        protected void AddScoreLevelDefinition(ScoreLevelBoundsDefinition scoreLevel)
        {
            ValidateLevel(scoreLevel);
            _scoreLevels.Add(scoreLevel.LowerBound, scoreLevel);
        }

        protected void AddScoreLevelDefinition(double lowerBound, double upperBound, string name)
        {
            var scoreLevel = new ScoreLevelBoundsDefinition(lowerBound, upperBound, name);
            AddScoreLevelDefinition(scoreLevel);
        }

        /// <summary>
        /// Adds a score level at the very beginning of the sequence of score, with a lowerbound of 0
        /// </summary>
        /// <param name="upperBound"></param>
        /// <param name="name"></param>
        protected void AddStartingScoreLevel(double upperBound, string name)
        {
            var scoreLevelDefinition = new ScoreLevelBoundsDefinition(0, upperBound, name);
            AddScoreLevelDefinition(scoreLevelDefinition);
        }

        /// <summary>
        /// Adds a final score level to the sequence, with an upper bound of 1.
        /// </summary>
        /// <param name="name"></param>
        protected void AddFinalScoreLevel(string name)
        {
            AddNextScoreLevelDefinitionInList(1, name);
        }

        /// <summary>
        /// Adds a score level into the list based on the score level "before it" such that the lower bounds of
        /// this added entry is the same as the upper bounds of the last item in the list. The lower bounds are 0 
        /// if no items are in the list.
        /// </summary>
        /// <param name="upperBound"></param>
        /// <param name="name"></param>
        protected void AddNextScoreLevelDefinitionInList(double upperBound, string name)
        {
            double lowerBound = 0;
            if (_scoreLevels.Count > 0)
            {
                lowerBound = _scoreLevels.Last().Value.UpperBound;
            }
            var scoreLevelDefinition = new ScoreLevelBoundsDefinition(lowerBound, upperBound, name);
            AddScoreLevelDefinition(scoreLevelDefinition);
        }

        private void ValidateLevel(ScoreLevelBoundsDefinition scoreLevel)
        {
            var areBoundsAlreadyUsed = _scoreLevels.Any(s => s.Value.LowerBound == scoreLevel.LowerBound || s.Value.UpperBound == scoreLevel.UpperBound);
            if (areBoundsAlreadyUsed)
            {
                throw new CognitiveServicesArgumentException("The Lower or Upper bounds value are already defined.");
            }
        }

        public void ValidateScoreLevelList()
        {
            if (_scoreLevels.Count == 0)
            {
                throw new CognitiveServicesArgumentException("No score levels defined.");
            }

            // Ensure we have the full range of values covered (ie. from 0 to 1) by start and end elements
            if (_scoreLevels.ElementAt(0).Value.LowerBound != 0 || _scoreLevels.ElementAt(_scoreLevels.Count - 1).Value.UpperBound != 1)
            {
                throw new CognitiveServicesException("List is not valid. Does not cover all values between 0 and 1");
            }

            if (_scoreLevels.Count > 1)
            {
                for (var itemCnt = 0; itemCnt < _scoreLevels.Count - 2; itemCnt++) // exclude the last item
                {
                    var currentScoreItem = _scoreLevels.ElementAt(itemCnt).Value;
                    var nextScoreItem = _scoreLevels.ElementAt(itemCnt+1).Value;
                    if (currentScoreItem.UpperBound != nextScoreItem.LowerBound)
                    {
                        throw new CognitiveServicesArgumentException("Previous score level upper bound value must match next score level lower bound value.");
                    }
                }
            }

        }
    }

}
