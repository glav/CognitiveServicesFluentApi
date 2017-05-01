using Glav.CognitiveServices.FluentApi.Core.Communication;

namespace Glav.CognitiveServices.FluentApi.Core.Contracts
{
    public interface IApiRequestResult<T> : IApiCallResult where T : IActionResponseRoot
    {
        T ResponseData { get;  }

    }

}
