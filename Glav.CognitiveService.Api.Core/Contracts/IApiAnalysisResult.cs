namespace Glav.CognitiveServices.Api.Core.Contracts
{
    public interface IApiAnalysisResult<T> : IApiCallResult where T : IActionResponseRoot
    {

        T ResponseData { get;  }

    }

}
