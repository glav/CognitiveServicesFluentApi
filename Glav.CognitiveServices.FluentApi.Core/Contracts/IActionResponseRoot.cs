using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IActionResponseRoot
    {
    }

    public interface IActionResponseRootWithError : IActionResponseRoot
    {
        BaseApiErrorResponse error { get; set; }
    }
}
