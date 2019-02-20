using Xunit;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Face;
using System.Linq;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class LargePersonGroupPersonTests
    {
        private TestDataHelper _helper = new TestDataHelper();

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonDeleteResultSuccessfully()
        {
            var commsEngine = new MockCommsEngine(new MockCommsResult(null, System.Net.HttpStatusCode.OK));
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithFaceAnalysisActions()
                .DeleteLargePersonGroupPerson("123","456")
                .AnalyseAllAsync();

            Assert.NotNull(result.LargePersonGroupPersonDeleteAnalysis);
            Assert.NotNull(result.LargePersonGroupPersonDeleteAnalysis.AnalysisResult);
            Assert.NotNull(result.LargePersonGroupPersonDeleteAnalysis.AnalysisResult.ApiCallResult);
            Assert.True(result.LargePersonGroupPersonDeleteAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.True(result.LargePersonGroupPersonDeleteAnalysis.IsSuccessfull());
        }

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonCreateResultSuccessfully()
        {
            const string returnData = "{    \"personId\": \"25985303-c537-4467-b41d-bdb45cd95ca1\"  }";
            var commsEngine = new MockCommsEngine(new MockCommsResult(returnData));
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithFaceAnalysisActions()
                .CreateLargePersonGroupPerson("123", "unittest","unittest-data")
                .AnalyseAllAsync();

            Assert.NotNull(result.LargePersonGroupPersonCreateAnalysis);
            Assert.NotNull(result.LargePersonGroupPersonCreateAnalysis.AnalysisResult);
            Assert.NotNull(result.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ApiCallResult);
            Assert.True(result.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotNull(result.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ResponseData);
            Assert.NotNull(result.LargePersonGroupPersonCreateAnalysis.AnalysisResult.ResponseData.personId);
        }

        [Fact]
        public async Task ShouldParseLargePersonGroupPersonListResultSuccessfully()
        {
            var returnData = _helper.GetFileDataEmbeddedInAssembly("FaceLargePersonGroupPersonListResponse.json");
            var commsEngine = new MockCommsEngine(new MockCommsResult(returnData));
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                .AddConsoleDiagnosticLogging()
                .UsingCustomCommunication(commsEngine)
                .WithFaceAnalysisActions()
                .ListLargePersonGroupPersons("123")
                .AnalyseAllAsync();

            Assert.NotNull(result.LargePersonGroupPersonListAnalysis);
            Assert.NotNull(result.LargePersonGroupPersonListAnalysis.AnalysisResult);
            Assert.NotNull(result.LargePersonGroupPersonListAnalysis.AnalysisResult.ApiCallResult);
            Assert.True(result.LargePersonGroupPersonListAnalysis.AnalysisResult.ActionSubmittedSuccessfully);
            Assert.NotNull(result.LargePersonGroupPersonListAnalysis.AnalysisResult.ResponseData);
            Assert.NotEmpty(result.LargePersonGroupPersonListAnalysis.AnalysisResult.ResponseData.LargePersonGroupPersons);

            var resultData = result.LargePersonGroupPersonListAnalysis.GetResults();
            Assert.Equal(2,resultData.Count());

            // Check first result
            var firstResult = resultData.First();
            Assert.Equal("25985303-c537-4467-b41d-bdb45cd95ca1", firstResult.personId);
            Assert.Equal("person-name1", firstResult.name);
            Assert.Equal("User-provided data attached to the person.", firstResult.userData);
            Assert.NotEmpty(firstResult.persistedFaceIds);
            Assert.Equal(3,firstResult.persistedFaceIds.Length);
            Assert.Equal("015839fb-fbd9-4f79-ace9-7675fc2f1dd9", firstResult.persistedFaceIds[0]);
            Assert.Equal("fce92aed-d578-4d2e-8114-068f8af4492e", firstResult.persistedFaceIds[1]);
            Assert.Equal("b64d5e15-8257-4af2-b20a-5a750f8940e7", firstResult.persistedFaceIds[2]);

            // Do some checks on the second result, but not as many
            var lastResult = resultData.Last();
            Assert.Equal("2ae4935b-9659-44c3-977f-61fac20d0538", lastResult.personId);
            Assert.Equal("person-name2", lastResult.name);
            Assert.NotEmpty(lastResult.persistedFaceIds);
            Assert.Equal(2, lastResult.persistedFaceIds.Length);
            Assert.Equal("fbd2a038-dbff-452c-8e79-2ee81b1aa84e", lastResult.persistedFaceIds[1]);
        }

    }

}
