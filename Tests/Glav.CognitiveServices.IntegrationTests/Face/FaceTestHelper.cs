using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Face;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.IntegrationTests.Face
{
    public static class FaceTestHelper
    {
        public static FaceConfigurationSettings CreateFaceConfig()
        {
            return FaceConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.FaceApiKey, LocationKeyIdentifier.AustraliaEast, 10);
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
                var delResult = await FaceTestHelper.CreateFaceConfig()
                    .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors)
                    .AddConsoleAndTraceLogging()
                    .UsingHttpCommunication()
                    .WithFaceAnalysisActions()
                    .DeleteLargePersonGroup(group.largePersonGroupId)
                    .AnalyseAllAsync();
            }

        }
    }
}
