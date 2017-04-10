using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.TextAnalytic
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
