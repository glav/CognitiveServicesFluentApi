﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public class ScoreLevelBoundsDefinition : IScoreLevelBoundsDefinition
    {
        public ScoreLevelBoundsDefinition(double lowerBound, double upperBound, string name)
        {
            Validate(lowerBound, upperBound, name);
            LowerBound = lowerBound;
            UpperBound = upperBound;
            Name = name;
            CanonicalName = name.ToLowerInvariant();
        }

        private void Validate(double lowerBound, double upperBound, string name)
        {
            if (lowerBound < 0 || lowerBound >= 1)
            {
                throw new CognitiveServicesArgumentException("Lowerbound value cannot be less than zero or equal to 1.");
            }
            if (upperBound <= 0 || upperBound > 1)
            {
                throw new CognitiveServicesArgumentException("Upperbound value cannot be <= 0 or greater than 1");
            }

            if (lowerBound >= upperBound)
            {
                throw new CognitiveServicesArgumentException("Lowerbound value must be less than the Upperbound value.");
            }
        }

        public double LowerBound { get; }
        public double UpperBound { get; }
        public string Name { get; }
        public string CanonicalName { get; }
    }
}
