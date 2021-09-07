using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation
{
    public class ScoreException : ApplicationException
    {
        public ScoreException(string message) : base(message)
        {
        }

        public ScoreException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
