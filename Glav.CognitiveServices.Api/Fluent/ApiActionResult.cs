using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public class ApiActionResult : IAPiActionResult
    {
        private readonly IApiActionResultData _actionResult;

        public ApiActionResult(Guid actionId, IApiAction actionPerformed, IApiActionResultData actionResult)
        {
            ActionId = actionId;
            ActionPerformed = ActionPerformed;
            _actionResult = actionResult;
        }
        public Guid ActionId { get; private set; }
        public IApiAction ActionPerformed { get; private set; }

        public T ActionResult<T>() where T : class, IApiActionResultData
        {
            return _actionResult as T;
        }
    }
}
