using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;
using System.Net;

namespace Glav.CognitiveServices.UnitTests
{
    public class MockCommsResult : ICommunicationResult
    {
        public MockCommsResult(string data)
        {
            Data = data;
        }
        public string Data { get; set; }

        public string ErrorMessage => null;

        public Uri LocationUri => new Uri("http://dummy");

        public Uri OperationLocationUri => new Uri("http://dummy");

        public Guid RequestId => Guid.NewGuid();

        public HttpStatusCode StatusCode => HttpStatusCode.OK;

        public bool Successfull => true;
    }
}
