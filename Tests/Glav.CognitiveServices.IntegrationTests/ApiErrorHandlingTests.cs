using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using Glav.CognitiveServices.FluentApi.Face;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.IntegrationTests.TextAnalytic
{
    public class ApiErrorHandlingTests
    {
        [Fact]
        public async Task InvalidApiKeyForSentimentAnalysisShouldbereflectedInErrorResults()
        {
            var result = await TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("some bogus key", LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithTextAnalyticAnalysisActions()
                .AddSentimentAnalysis("I am having a fantastic time.")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.SentimentAnalysis);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult.ApiCallResult);
            Assert.False(result.SentimentAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotNull(result.SentimentAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.SentimentAnalysis.AnalysisResult.ResponseData.errors);
            Assert.Equal("401", result.SentimentAnalysis.AnalysisResult.ResponseData.errors[0].code);
        }

        [Fact]
        public async Task InvalidApiKeyForFaceDetectionShouldbereflectedInErrorResults()
        {
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("some bogus key", LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .AddUriForFaceDetection(new System.Uri("http://somwhere.com/img.jpg"),FluentApi.Face.Domain.FaceDetectionAttributes.Accessories)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.FaceDetectionAnalysis);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ApiCallResult);
            Assert.False(result.FaceDetectionAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ResponseData);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ResponseData.error);
            Assert.Equal("401", result.FaceDetectionAnalysis.AnalysisResult.ResponseData.error.code);
        }

        [Fact]
        public async Task CommunicationFailureShouldbereflectedInErrorResults()
        {
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("some bogus key", LocationKeyIdentifier.WestUs)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddDebugDiagnosticLogging()
                .UsingCustomCommunication(new FailureCommsEngine())
                .WithFaceAnalysisActions()
                .AddUriForFaceDetection(new System.Uri("http://somwhere.com/img.jpg"), FluentApi.Face.Domain.FaceDetectionAttributes.Accessories)
                .AnalyseAllAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.FaceDetectionAnalysis);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ApiCallResult);
            Assert.False(result.FaceDetectionAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ResponseData);
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ResponseData.error);
            Assert.Equal("Host not found", result.FaceDetectionAnalysis.AnalysisResult.ResponseData.error.message);
        }


    }

    public class FailureCommsEngine : ICommunicationEngine
    {
        public Task<ICommunicationResult> CallBatchServiceAsync(ApiActionDataCollection actionItemCollection)
        {
            return Task.FromResult<ICommunicationResult>(CommunicationResult.Fail("Host not found"));
        }

        public Task<ICommunicationResult> CallServiceAsync(IActionDataItem actionItem)
        {
            return Task.FromResult<ICommunicationResult>(CommunicationResult.Fail("Host not found"));
        }

        public Task<ICommunicationResult> ServiceGetAsync(string uri, string category)
        {
            return Task.FromResult<ICommunicationResult>(CommunicationResult.Fail("Host not found"));
        }
    }
}
 