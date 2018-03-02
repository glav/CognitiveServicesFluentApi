using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Operations
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
