using Xunit;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.UnitTests.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using Glav.CognitiveServices.FluentApi.Face.Domain;
using Glav.CognitiveServices.FluentApi.Face;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class FaceDetectionParsingTests
    {
        private TestDataHelper _helper = new TestDataHelper();

        [Fact]
        public void ShouldParseFaceDetectionResultSuccessfully()
        {
            var input = _helper.GetFileDataEmbeddedInAssembly("FaceDetectionResponse.json");
            var result = new FaceDetectionResult(new MockCommsResult(input));

            Assert.NotNull(result);
            Assert.NotNull(result.ApiCallResult);
            Assert.True(result.ActionSubmittedSuccessfully);
            Assert.NotNull(result.ResponseData);
            Assert.Null(result.ResponseData.error);
            Assert.NotEmpty(result.ResponseData.detectedFaces);
            Assert.Equal<long>(1, result.ResponseData.detectedFaces.Length);

            var responseItem = result.ResponseData.detectedFaces[0];
            Assert.Equal("c5c24a82-6845-4031-9d5d-978df9175426", responseItem.faceId);
            
        }

        [Fact]
        public async Task ShouldParseFaceDetectionResultThroughPipelineSuccessfully()
        {
            var input = _helper.GetFileDataEmbeddedInAssembly("FaceDetectionResponse.json");
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                    .AddConsoleAndTraceLogging()
                    .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(input)))
                    .WithFaceAnalysisActions()
                    .AddUrlForFaceDetection("http://whatever",FaceDetectionAttributes.Age)
                    .AnalyseAllAsync();

            Assert.NotNull(result);
            result.FaceDetectionAnalysis.AssertAnalysisContextValidity();
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ResponseData);

            var resultData = result.FaceDetectionAnalysis.AnalysisResult.ResponseData;
            Assert.NotEmpty(resultData.detectedFaces);
            Assert.Equal(1,resultData.detectedFaces.Length);
        }

        [Fact]
        public async Task ShouldParseFaceDetectionResultThroughPipelineForGenderFemaleAndAgeSuccessfully()
        {
            var input = _helper.GetFileDataEmbeddedInAssembly("FaceDetectionResponse-FemaleWithAge.json");
            var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
                    .AddConsoleDiagnosticLogging()
                    .UsingCustomCommunication(new MockCommsEngine(new MockCommsResult(input)))
                    .WithFaceAnalysisActions()
                    .AddUrlForFaceDetection("http://whatever", FaceDetectionAttributes.Age)
                    .AnalyseAllAsync();

            Assert.NotNull(result);
            result.FaceDetectionAnalysis.AssertAnalysisContextValidity();
            Assert.NotNull(result.FaceDetectionAnalysis.AnalysisResult.ResponseData);

            var resultData = result.FaceDetectionAnalysis.AnalysisResult.ResponseData;
            Assert.NotEmpty(resultData.detectedFaces);
            Assert.Equal(1, resultData.detectedFaces.Length);
            Assert.NotNull(resultData.detectedFaces[0].faceAttributes);
            Assert.NotNull(resultData.detectedFaces[0].faceAttributes.gender);
            Assert.Equal(GenderType.Female, resultData.detectedFaces[0].faceAttributes.gender.ToGenderType());
            Assert.Equal(24.0, resultData.detectedFaces[0].faceAttributes.age);
        }

        [Fact]
        public void ShouldParseGenderIntoType()
        {
            Assert.Equal(GenderType.Female, "fEmAlE".ToGenderType());
            Assert.Equal(GenderType.Male, "mAlE".ToGenderType());
            Assert.Equal(GenderType.Genderless, "Gorilla".ToGenderType());
            Assert.Equal(GenderType.Genderless, " ".ToGenderType());
        }

        [Fact]
        public void ShouldParseGlassesIntoType()
        {
            Assert.Equal(GlassesType.ReadingGlasses, "ReadingglasseS".ToGlassesType());
            Assert.Equal(GlassesType.NoGlasses, "blah".ToGlassesType());
            Assert.Equal(GlassesType.Sunglasses, "sunGlasSes".ToGlassesType());
            Assert.Equal(GlassesType.SwimmingGoggles, "SwiMminGGoggles".ToGlassesType());
        }

        [Fact]
        public void ShouldParseHairColorIntoType()
        {
            Assert.Equal(HairColor.Brown, "brOwn".ToHairColor());
            Assert.Equal(HairColor.Unknown, "blur and green".ToHairColor());
        }



    }
}
