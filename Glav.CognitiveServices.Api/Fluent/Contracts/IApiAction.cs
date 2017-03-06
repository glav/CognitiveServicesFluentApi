using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.Contracts
{
    public interface IApiAction<T> where T : class, IApiActionData
    {
        ApiActionType ActionType { get;  }

        T ActionData();
    }
}
