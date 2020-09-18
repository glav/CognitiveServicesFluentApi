using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System.Linq;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.Helpers
{
    public static class TestExtensions
    {
        public static void AssertAnalysisContextValidity<TResult, TError>(this BaseApiAnalysisContext<TResult, TError> analysisContext) where TResult : IApiCallResult where TError : class
        {
            Assert.NotNull(analysisContext);
            Assert.NotNull(analysisContext.AnalysisResults);

            var anyErrors = analysisContext.AnalysisResults.Any(c => c.ActionSubmittedSuccessfully == false);
            var potentialError = analysisContext.AnalysisResults.FirstOrDefault(c => c.ActionSubmittedSuccessfully == false);
            Assert.False(anyErrors,$"One or more actions failed {potentialError?.ApiCallResult?.ErrorMessage}, Code: {potentialError?.ApiCallResult?.StatusCode}");
        }
    }
}
