namespace Glav.CognitiveServices.FluentApi.Core.Communication
{
    public class BaseApiErrorResponse : IBaseApiErrorResponse
    {
        public string code { get; set; }
        public string message { get; set; }

    }
}
