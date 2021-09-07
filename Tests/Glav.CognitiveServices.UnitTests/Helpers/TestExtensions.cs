using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Glav.CognitiveServices.UnitTests.Helpers
{
    public static class TestExtensions
    {
        public static void AssertAnalysisContextValidity<TResult, TError, TScoreItem>(this BaseApiAnalysisContext<TResult, TError, TScoreItem> analysisContext) where TResult : IApiCallResult where TError : class
        {
            Assert.NotNull(analysisContext);
            Assert.NotNull(analysisContext.AnalysisResult);
            Assert.NotNull(analysisContext.AnalysisResult.ApiCallResult);
            Assert.True(analysisContext.AnalysisResult.ActionSubmittedSuccessfully);
        }
    }
}
