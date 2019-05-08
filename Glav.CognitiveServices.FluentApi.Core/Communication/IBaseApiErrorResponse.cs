namespace Glav.CognitiveServices.FluentApi.Core.Communication
{
    public interface IBaseApiErrorResponse
    {
        string code { get; set; }
        string message { get; set; }
    }
}