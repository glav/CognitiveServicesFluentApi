using Glav.CognitiveServices.Api.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public sealed class ApiAction
    {
        public ApiAction(ApiActionType actionType, string actionData)
        {
            ActionType = actionType;
            ActionData = actionData;
        }
        public ApiActionType ActionType { get; private set; }
        public string ActionData { get; private set; }
    }
}
