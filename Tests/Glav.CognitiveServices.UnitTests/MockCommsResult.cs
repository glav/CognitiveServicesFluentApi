﻿using Glav.CognitiveServices.FluentApi.Core.Communication;
using System;
using System.Net;

namespace Glav.CognitiveServices.UnitTests
{
    public class MockCommsResult : ICommunicationResult
    {
        public MockCommsResult(string data)
        {
            Data = data;
            StatusCode = HttpStatusCode.OK;
            OperationLocationUri = new Uri("http://dummy");
        }

        public MockCommsResult(string data, HttpStatusCode statusCodeToReturn) : this(data)
        {
            StatusCode = statusCodeToReturn;
            OperationLocationUri = new Uri("http://dummy");
        }

        public MockCommsResult(HttpStatusCode statusCodeToReturn, string operationLocationUrl)
        {
            StatusCode = statusCodeToReturn;
            OperationLocationUri = new Uri(operationLocationUrl);
        }

        public string Data { get; set; }

        public string ErrorMessage => null;

        public Uri LocationUri => new Uri("http://dummy");

        public Uri OperationLocationUri { get; private set; }

        public Guid RequestId => Guid.NewGuid();

        public HttpStatusCode StatusCode { get; private set; }

        public bool Successfull => true;

        public RequestRateLimitStatus Ratelimit => new RequestRateLimitStatus();
    }
}
