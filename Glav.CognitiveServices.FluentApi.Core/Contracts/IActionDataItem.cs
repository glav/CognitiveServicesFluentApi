using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IActionDataItem
    {
        long Id { get;  }
        ApiActionType ApiType { get; }
        string ToUrlQueryParameters();
        bool IsBinaryData { get;  }
    }
}
