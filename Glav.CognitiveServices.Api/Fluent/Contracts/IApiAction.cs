using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.Contracts
{
    public interface IApiAction
    {
        ApiActionType ActionType { get;  }

        T ActionData<T>() where T : class, IApiActionData;
    }
}
