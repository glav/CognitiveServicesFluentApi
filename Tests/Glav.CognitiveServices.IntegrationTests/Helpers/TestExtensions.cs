using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Xunit;

namespace Glav.CognitiveServices.IntegrationTests.Helpers
{
    public static class TestExtensions
    {
        public static void AssertAnalysisContextValidity<TResult>(this BaseApiAnalysisContext<TResult> analysisContext) where TResult : IApiCallResult
        {
            Assert.NotNull(analysisContext);
            Assert.NotNull(analysisContext.AnalysisResult);
            Assert.NotNull(analysisContext.AnalysisResult.ApiCallResult);
            Assert.True(analysisContext.AnalysisResult.ActionSubmittedSuccessfully, $"Failed: {analysisContext.AnalysisResult.ApiCallResult.ErrorMessage}, Code: {analysisContext.AnalysisResult.ApiCallResult.StatusCode}");
        }
    }
}
