using Glav.CognitiveServices.Api.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Core.Contracts
{
    public interface IActionDataItem
    {
        ApiActionType ApiType { get; }
    }
}
