using Xunit;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class TextAnalyticParsingTests
    {
        [Fact]
        public void ShouldParseResultSuccessfully()
        {
            var input = "{\"documents\":[{\"score\":0.7988085,\"id\":\"1\"}],\"errors\":[]}";
            var result = new SentimentResult(new MockCommsResult(input));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.NotEmpty(result.ResponseData.documents);
            Assert.Equal<long>(1, result.ResponseData.documents[0].id);
            Assert.Equal<double>(0.7988085, result.ResponseData.documents[0].score);
            Assert.Empty(result.ResponseData.errors);
        }

        [Fact]
        public void ShouldParseErrorResultSuccessfully()
        {
            var input = "{\"code\":\"BadRequest\",\"message\":\"Invalid request\",\"innerError\":{\"code\":\"InvalidRequestBodyFormat\",\"message\":\"Request body format is wrong.Make sure the json request is serialized correctly and there are no null members.\"}}";
            var result = new SentimentResult(new MockCommsResult(input,System.Net.HttpStatusCode.BadRequest));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.False(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.NotEmpty(result.ResponseData.errors);
            Assert.Equal(1, result.ResponseData.errors.Length);
            Assert.Equal("BadRequest", result.ResponseData.errors[0].code);
            Assert.Equal("Invalid request", result.ResponseData.errors[0].message);
            Assert.NotNull(result.ResponseData.errors[0].InnerError);
            Assert.Equal("InvalidRequestBodyFormat", result.ResponseData.errors[0].InnerError.code);
            Assert.Equal("Request body format is wrong.Make sure the json request is serialized correctly and there are no null members.", result.ResponseData.errors[0].InnerError.message);
        }

    }
}
