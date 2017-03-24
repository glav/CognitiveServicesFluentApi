using System;
using System.Net;

namespace Glav.CognitiveServices.Api.Communication
{
    public interface ICommunicationResult
    {
        string Data { get; }
        string ErrorMessage { get; }
        Uri LocationUri { get; }
        Uri OperationLocationUri { get; }
        Guid RequestId { get; }
        HttpStatusCode StatusCode { get; }
        bool Successfull { get; }
    }
}