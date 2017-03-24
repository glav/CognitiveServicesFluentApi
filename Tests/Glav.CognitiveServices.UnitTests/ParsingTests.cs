using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Configuration;
using System;
using Xunit;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using Glav.CognitiveServices.Api.Communication;
using System.Net;

namespace Glav.CognitiveServices.UnitTests
{
    public class ParsingTests
    {
        [Fact]
        public void ShouldParseResultSuccessfully()
        {
            var input = "{\"documents\":[{\"score\":0.7988085,\"id\":\"1\"}],\"errors\":[]}";
            var result = new SentimentResult(new MockSentimentResult(input));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.Successfull);
            Assert.NotNull(result.ResponseData);
            Assert.NotEmpty(result.ResponseData.documents);
            Assert.Equal<long>(1, result.ResponseData.documents[0].id);
            Assert.Equal<double>(0.7988085, result.ResponseData.documents[0].score);
            Assert.Empty(result.ResponseData.errors);
        }
    }

    public class MockSentimentResult : ICommunicationResult
    {
        public MockSentimentResult(string data)
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
