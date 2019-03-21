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
    public class LargePersonGroupPersonApiTests
    {
        private TestDataHelper _testDataHelper = new TestDataHelper();
        [Fact]
        public async Task ShouldBeAbleToCreateLargePersonGroupPerson()
        {
            var groupId = System.Guid.NewGuid().ToString();
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .AddAllDefaultLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .CreateLargePersonGroup(groupId,$"Unittest-{groupId}")
                .CreateLargePersonGroupPerson(groupId, $"UnittestPerson-{groupId}","person-userdata")
                .AnalyseAllAsync();

            Assert.NotNull(result);
            result.LargePersonGroupCreateAnalysis.AssertAnalysisContextValidity();
            Assert.Equal(HttpStatusCode.OK, result.LargePersonGroupCreateAnalysis.AnalysisResult.ApiCallResult.StatusCode);
        }

        [Fact]
            public async Task ShouldBeAbleToGetLargePersonGroupPerson()
        {
            var groupId = System.Guid.NewGuid().ToString();
            var groupName = $"integrationtest-{groupId}";

            var createResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddAllDefaultLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .CreateLargePersonGroup(groupId,groupName)
                .CreateLargePersonGroupPerson(groupId,"testname","farout")
                .AnalyseAllAsync();

            createResult.LargePersonGroupCreateAnalysis.AssertAnalysisContextValidity();
            createResult.LargePersonGroupPersonCreateAnalysis.AssertAnalysisContextValidity();

            var personId = createResult.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ResponseData.personId;

            var getResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddAllDefaultLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .GetLargePersonGroupPerson(groupId,personId)
                .AnalyseAllAsync();

            Assert.NotNull(getResult);
            Assert.NotNull(getResult.LargePersonGroupPersonGetAnalysis);
            getResult.LargePersonGroupPersonGetAnalysis.AssertAnalysisContextValidity();
            Assert.NotNull(getResult.LargePersonGroupPersonGetAnalysis.AnalysisResult.ResponseData.LargePersonGroupPerson);
        }

        [Fact]
        public async Task ShouldBeAbleToListLargePersonGroupPersons()
        {
            var groupId = System.Guid.NewGuid().ToString();
            var groupName = $"integrationtest-{groupId}";

            var createResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .CreateLargePersonGroup(groupId, groupName)
                .CreateLargePersonGroupPerson(groupId,"personName","whatever")
                .AnalyseAllAsync();

            Assert.True(createResult.LargePersonGroupCreateAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.True(createResult.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ActionSubmittedSuccessfully);

            var listResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddDebugDiagnosticLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .ListLargePersonGroupPersons(groupId)
                .AnalyseAllAsync();

            Assert.NotNull(listResult);
            listResult.LargePersonGroupPersonListAnalysis.AssertAnalysisContextValidity();
            Assert.NotEmpty(listResult.LargePersonGroupPersonListAnalysis.AnalysisResult.ResponseData.LargePersonGroupPersons);
            Assert.False(string.IsNullOrWhiteSpace(listResult.LargePersonGroupPersonListAnalysis.AnalysisResult.ResponseData.LargePersonGroupPersons[0].name));
        }

    }
}
