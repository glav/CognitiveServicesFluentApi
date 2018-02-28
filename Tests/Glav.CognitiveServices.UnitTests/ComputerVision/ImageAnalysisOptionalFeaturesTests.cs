using Xunit;
using Glav.CognitiveServices.FluentApi.ComputerVision;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class ImageAnalysisOptionalFeaturesTests
    {

        [Fact]
        public void VisualFeaturesShouldFormUrlArguments()
        {
            var features = ImageAnalysisVisualFeatures.Adult | ImageAnalysisVisualFeatures.Faces;
            var expected = $"{FluentApi.ComputerVision.Configuration.ApiConstants.ImageAnalysisVisualFeaturesUrlParameterName}=Faces,Adult";
            var actual = features.ToUrlQueryParameters();

            Assert.Equal(expected, actual);

            features = ImageAnalysisVisualFeatures.Default;
            expected = string.Empty;
            actual = features.ToUrlQueryParameters();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UrlArgumentsForAllOptionsShouldBeValidQueryParameters()
        {
            var actionData = new ImageAnalysisActionData(new System.Uri("https://localhost"), ImageAnalysisVisualFeatures.Categories | ImageAnalysisVisualFeatures.Faces, ImageAnalysisDetails.Celebrities, FluentApi.Core.SupportedLanguageType.English);
            var actual = actionData.ToUrlQueryParameters();
            var expected = "visualFeatures=Categories,Faces&details=Celebrities&language=en";
            Assert.Equal(expected, actual);

            actionData = new ImageAnalysisActionData(new System.Uri("https://localhost"),ImageAnalysisVisualFeatures.Default, ImageAnalysisDetails.Landmarks,FluentApi.Core.SupportedLanguageType.Unspecified);
            actual = actionData.ToUrlQueryParameters();
            expected = "details=Landmarks";
            Assert.Equal(expected, actual);

        }

    }
}
