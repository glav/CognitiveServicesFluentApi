using Xunit;
using Glav.CognitiveServices.FluentApi.Emotion.Domain;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.UnitTests.Helpers;
using System.Linq;
using Glav.CognitiveServices.FluentApi.ComputerVision;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.UnitTests.Emotion
{
    public class ImageAnalysisOptionalFeaturesTests
    {

        [Fact]
        public void VisualFeaturesShouldFormUrlArguments()
        {
            var features = ImageAnalysisVisualFeatures.Adult | ImageAnalysisVisualFeatures.Faces;
            var expected = "Faces,Adult";
            var actual = features.ToUrlArguments();
            Assert.Equal(expected, actual);

            features = ImageAnalysisVisualFeatures.Default;
            expected = string.Empty;
            actual = features.ToUrlArguments();
            Assert.Equal(expected, actual);
        }

    }
}
