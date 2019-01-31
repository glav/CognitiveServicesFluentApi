using Xunit;
using Glav.CognitiveServices.FluentApi.ComputerVision;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;

namespace Glav.CognitiveServices.UnitTests.ComputerVision
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

            features = ImageAnalysisVisualFeatures.None;
            expected = string.Empty;
            actual = features.ToUrlQueryParameters();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UrlArgumentsForAllOptionsShouldBeValidQueryParameters()
        {
            SupportedLanguages.Setup();

            var actionData = new ImageAnalysisActionDataItem(1,new System.Uri("https://localhost"), ImageAnalysisVisualFeatures.Categories | ImageAnalysisVisualFeatures.Faces, ImageAnalysisDetails.Celebrities, FluentApi.Core.SupportedLanguageType.English);
            var actual = actionData.ToUrlQueryParameters();
            var expected = "visualFeatures=Categories,Faces&details=Celebrities&language=en";
            Assert.Equal(expected, actual);

            actionData = new ImageAnalysisActionDataItem(2, new System.Uri("https://localhost"),ImageAnalysisVisualFeatures.None, ImageAnalysisDetails.Landmarks,FluentApi.Core.SupportedLanguageType.Unspecified);
            actual = actionData.ToUrlQueryParameters();
            expected = "details=Landmarks";
            Assert.Equal(expected, actual);

        }

    }
}
