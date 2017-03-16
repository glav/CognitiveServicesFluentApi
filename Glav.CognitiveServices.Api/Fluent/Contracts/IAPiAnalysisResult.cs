namespace Glav.CognitiveServices.Api.Fluent.Contracts
{
    public interface IApiAnalysisResult<T> : IApiCallResult where T : IActionResponseRoot
    {

        T ResponseData { get;  }

    }

}
