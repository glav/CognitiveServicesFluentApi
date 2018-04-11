using Xunit;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core.Operations;
using System;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class OperationStatusParsingTests
    {
        [Fact]
        public void ShouldParseResultSuccessfully()
        {
            var input = FormOperationStatusInput(OperationStatusResponseMessages.StatusSucceeded, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(5), string.Empty);
            var result = new OperationStatusResult(new MockCommsResult(input));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
        }

        private static string FormOperationStatusInput(string status, DateTime createdDateTime, DateTime? lastActionDateTime, string message )
        {

            return $"{{\"status\":\"{status}\"," +
                $"\"createdDateTime\":\"{createdDateTime.ToString()}\", " +
                $"\"lastActionDateTime\":\"{lastActionDateTime.ToString() ?? string.Empty}\", " +
                $"\"message\":\"{message}\",\"errors\":[]}}";
        }

    }
}
