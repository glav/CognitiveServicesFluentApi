using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Glav.CognitiveServices.UnitTests.Helpers
{
    public static class TestExtensions
    {
        public static void AssertAnalysisContextValidity<TResult>(this BaseApiAnalysisContext<TResult> analysisContext) where TResult : IApiCallResult
        {
            Assert.NotNull(analysisContext);
            Assert.NotNull(analysisContext.AnalysisResult);
            Assert.NotNull(analysisContext.AnalysisResult.ApiCallResult);
            Assert.True(analysisContext.AnalysisResult.ActionSubmittedSuccessfully);
        }
    }
}
