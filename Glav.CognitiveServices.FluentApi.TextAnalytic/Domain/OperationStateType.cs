using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public enum OperationStateType
    {
        NotStarted,
        BadRequest,
        Submitted,
        Running,
        CompletedSuccessfully,
        Failed,
        TimedOut,
        Cancelled
    }
}
