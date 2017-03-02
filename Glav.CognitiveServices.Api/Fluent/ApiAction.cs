using Glav.CognitiveServices.Api.Configuration;
using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public abstract class ApiAction : IApiAction
    {
        private IApiActionData _actionData;
        public ApiAction(ApiActionType actionType, IApiActionData actionData)
        {
            ActionType = actionType;
            _actionData = actionData;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public ApiActionType ActionType { get; private set; }
        public T ActionData<T>() where T : class, IApiActionData
        {
            return _actionData as T;
        }
    }
}
