using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IActionDataItem
    {
        long Id { get;  }
        ApiActionDefinition ApiDefintition { get; }
        string ToUrlQueryParameters();
        string ToEndUriFragment();
        bool IsBinaryData { get;  }
        byte[] ToBinary();
    }
}
