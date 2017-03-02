using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.Contracts
{
    public interface IAPiActionResult
    {
        Guid ActionId { get;  }
        IApiAction ActionPerformed { get; }
        T ActionResult<T>() where T : class, IApiActionResultData;
    }
}
