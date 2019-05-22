using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.IntegrationTests.Helpers
{
    public class TestDataHelper
    {
        public byte[] GetFileDataEmbeddedInAssembly(string filename)
        {
            var asm = this.GetType().GetTypeInfo().Assembly;
            using (var stream = asm.GetManifestResourceStream($"Glav.CognitiveServices.IntegrationTests.TestData.{filename}"))
            {
                using (var sr = new System.IO.BinaryReader(stream))
                using (var mem = new System.IO.MemoryStream())
                {
                    sr.BaseStream.CopyTo(mem);
                    return mem.ToArray();
                }
            }
        }

        public const string GroupId = "6998a312-6fd7-41b8-b328-1e1580438203";
        public const string PersonName = "Person-integration-test";
        public const string GroupName = "IntegrationTest";

        public async Task<OpResult> EnsureLargePersonGroupIsSetupAsync(string groupId = null)
        {
            var groupIdToUse = groupId ?? GroupId;
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .AddConsoleAndTraceLogging()
                .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .GetLargePersonGroup(groupIdToUse)
                .AnalyseAllAsync();

            if (result.LargePersonGroupGetAnalysis.AnalysisResult.ApiCallResult.Successfull &&
                     !string.IsNullOrWhiteSpace(result.LargePersonGroupGetAnalysis.AnalysisResult.ResponseData.LargePersonGroup.largePersonGroupId))
            {
                var personResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .AddConsoleAndTraceLogging()
                .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .ListLargePersonGroupPersons(GroupId)
                .AnalyseAllAsync();

                var person = personResult.LargePersonGroupPersonListAnalysis.AnalysisResult.ResponseData.LargePersonGroupPersons.FirstOrDefault();
                if (person != null)
                {

                    return new OpResult
                    {
                        Success = true,
                        PersonId = person.personId,
                        GroupId = groupIdToUse
                    };
                }

                var addPersonResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
                .AddConsoleAndTraceLogging()
                .SetDiagnosticLoggingLevel(LoggingLevel.ErrorsOnly)
                .UsingHttpCommunication()
                .WithFaceAnalysisActions()
                .CreateLargePersonGroupPerson(groupIdToUse,PersonName, "Used for integration testing only")
                .AnalyseAllAsync();

                if (addPersonResult.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ActionSubmittedSuccessfully)
                {
                    return new OpResult { GroupId = groupIdToUse, Success = true, PersonId = addPersonResult.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ResponseData.personId };
                }
            }

            // Create a group and person within the group
            var groupResult = await FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast)
            .AddConsoleAndTraceLogging()
            .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
            .UsingHttpCommunication()
            .WithFaceAnalysisActions()
            .CreateLargePersonGroup(groupIdToUse, GroupName)
            .CreateLargePersonGroupPerson(groupIdToUse, PersonName, "Used for integration testing only - can be deleted")
            .AnalyseAllAsync();

            if (groupResult.LargePersonGroupPersonCreateAnalysis.AnalysisResult != null
                && groupResult.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ActionSubmittedSuccessfully &&
                groupResult.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ResponseData != null &&
                !string.IsNullOrWhiteSpace(groupResult.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ResponseData.personId))
            {
                return new OpResult
                {
                    Success = true,
                    PersonId = groupResult.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ResponseData.personId,
                    GroupId = groupIdToUse
                };
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
