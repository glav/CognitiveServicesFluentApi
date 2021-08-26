using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face;
using Glav.CognitiveServices.FluentApi.Face.Configuration;
using Glav.CognitiveServices.IntegrationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.IntegrationTests.Face
{
    public static class FaceTestHelper
    {
        public static FaceConfigurationSettings CreateFaceConfig()
        {
            return FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast,ApiConstants.DEFAULT_FACE_VERSION, 10);
        }

        public static async Task DeleteLargePersonGroup(string groupId)
        {
            var delResult = await FaceTestHelper.CreateFaceConfig()
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddConsoleAndTraceLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .DeleteLargePersonGroup(groupId)
                .AnalyseAllAsync();
            delResult.LargePersonGroupDeleteAnalysis.AssertAnalysisContextValidity();
        }

        public static async Task DeleteAllLargePersonGroups()
        {
            var listResult = await FaceTestHelper.CreateFaceConfig()
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .AddConsoleAndTraceLogging()
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .ListLargePersonGroups()
                .AnalyseAllAsync();

            if (!listResult.LargePersonGroupListAnalysis.AnalysisResult.ActionSubmittedSuccessfully || listResult.LargePersonGroupListAnalysis.AnalysisResult.ResponseData.LargePersonGroups.Length == 0)
            {
                return;
            }
            foreach (var group in listResult.LargePersonGroupListAnalysis.AnalysisResult.ResponseData.LargePersonGroups)
            {
                await DeleteLargePersonGroup(group.largePersonGroupId);
            }

        }

        public const string GroupId = "6998a312-6fd7-41b8-b328-1e1580438203";
        public const string PersonName = "Person-integration-test";
        public const string GroupName = "IntegrationTest";

        public static async Task<OpResult> EnsureLargePersonGroupIsSetupAsync(string groupId = null)
        {
            // Only uncomment this if you want to clean up old person groups during some testing.
            //await DeleteAllLargePersonGroups();

            var groupIdToUse = groupId ?? GroupId;
            var result = await FaceTestHelper.CreateFaceConfig()
                .AddConsoleAndTraceLogging()
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .GetLargePersonGroup(groupIdToUse)
                .AnalyseAllAsync();

            if (!result.LargePersonGroupGetAnalysis.AnalysisResult.ApiCallResult.Successfull)
            {
                await FaceTestHelper.CreateFaceConfig()
                .AddConsoleAndTraceLogging()
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .CreateLargePersonGroup(groupIdToUse, GroupName)
                .AnalyseAllAsync();
            }

            var personResult = await FaceTestHelper.CreateFaceConfig()
                .AddConsoleAndTraceLogging()
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .ListLargePersonGroupPersons(groupIdToUse)
                .AnalyseAllAsync();

            var person = personResult.LargePersonGroupPersonListAnalysis.AnalysisResult.ResponseData.LargePersonGroupPersons?.FirstOrDefault();
            if (person != null)
            {

                return new OpResult
                {
                    Success = true,
                    PersonId = person.personId,
                    GroupId = groupIdToUse
                };
            }

            var addPersonResult = await FaceTestHelper.CreateFaceConfig()
            .AddConsoleAndTraceLogging()
            .SetDiagnosticLoggingLevel(LoggingLevel.ErrorsOnly)
            .UsingHttpCommunication()
            .WithFaceAnalysisActions()
            .CreateLargePersonGroupPerson(groupIdToUse, PersonName, "Used for integration testing only")
            .AnalyseAllAsync();

            if (addPersonResult.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ActionSubmittedSuccessfully)
            {
                return new OpResult { GroupId = groupIdToUse, Success = true, PersonId = addPersonResult.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ResponseData.personId };
            }


            return new OpResult();
        }

    }

    public class OpResult
    {
        public string PersonId { get; set; }
        public string GroupId { get; set; }
        public bool Success { get; set; }
    }

}
