using Glav.CognitiveServices.Api.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Core.Contracts
{
    public interface IApiAction<T> where T : class, IApiActionData
    {
        ApiActionType ActionType { get;  }

        T ActionData();
    }
}
