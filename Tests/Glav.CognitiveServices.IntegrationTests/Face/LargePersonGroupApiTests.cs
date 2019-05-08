    using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Glav.CognitiveServices.IntegrationTests.Helpers;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using System.Net;

namespace Glav.CognitiveServices.IntegrationTests.ComputerVision
{
    public class LargePersonGroupApiTests
    {
        [Fact]
        public async Task ShouldBeAbleToCreateLargePersonGroup()
        {
            var groupId = System.Guid.NewGuid().ToString();
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddConsoleAndTraceLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .CreateLargePersonGroup(groupId,$"Unittest-{groupId}")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            result.LargePersonGroupCreateAnalysis.AssertAnalysisContextValidity();
            Assert.Equal(HttpStatusCode.OK, result.LargePersonGroupCreateAnalysis.AnalysisResult.ApiCallResult.StatusCode);
        }

        [Fact]
        public async Task ShouldBeAbleToGetLargePersonGroup()
        {
            var groupId = System.Guid.NewGuid().ToString();
            var groupName = $"integrationtest-{groupId}";

            var createResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddConsoleAndTraceLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .CreateLargePersonGroup(groupId,groupName )
                .AnalyseAllAsync();

            Assert.True(createResult.LargePersonGroupCreateAnalysis.AnalysisResult.ActionSubmittedSuccessfully);

            var getResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddConsoleAndTraceLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .GetLargePersonGroup(groupId)
                .AnalyseAllAsync();

            Assert.NotNull(getResult);
            Assert.NotNull(getResult.LargePersonGroupGetAnalysis);
            getResult.LargePersonGroupGetAnalysis.AssertAnalysisContextValidity();
            Assert.Equal(groupId, getResult.LargePersonGroupGetAnalysis.AnalysisResult.ResponseData.LargePersonGroup.largePersonGroupId);
            Assert.Equal(groupName, getResult.LargePersonGroupGetAnalysis.AnalysisResult.ResponseData.LargePersonGroup.name);
        }

        [Fact]
        public async Task ShouldBeAbleToListLargePersonGroups()
        {
            var groupId = System.Guid.NewGuid().ToString();
            var groupName = $"integrationtest-{groupId}";

            var createResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddConsoleAndTraceLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .CreateLargePersonGroup(groupId, groupName)
                .AnalyseAllAsync();

            createResult.LargePersonGroupCreateAnalysis.AssertAnalysisContextValidity();

            var listResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddConsoleAndTraceLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .ListLargePersonGroups()
                .AnalyseAllAsync();

            Assert.NotNull(listResult);
            Assert.NotNull(listResult.LargePersonGroupListAnalysis);
            listResult.LargePersonGroupListAnalysis.AssertAnalysisContextValidity();
            Assert.NotEmpty(listResult.LargePersonGroupListAnalysis.AnalysisResult.ResponseData.LargePersonGroups);
            Assert.False(string.IsNullOrWhiteSpace(listResult.LargePersonGroupListAnalysis.AnalysisResult.ResponseData.LargePersonGroups[0].largePersonGroupId));
        }

    }
}
