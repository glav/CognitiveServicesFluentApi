using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
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
