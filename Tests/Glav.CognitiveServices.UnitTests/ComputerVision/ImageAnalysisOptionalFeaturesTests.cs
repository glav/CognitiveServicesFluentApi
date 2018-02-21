using Xunit;
using Glav.CognitiveServices.FluentApi.ComputerVision;

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

    }
}
