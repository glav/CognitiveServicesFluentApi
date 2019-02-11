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
    public class FaceUrlTests
    {
        private TestDataHelper _helper = new TestDataHelper();

        [Fact]
        public void ShouldParseFaceDetectionResultSuccessfully()
        {
            var actionItem = new LargePersonGroupGetActionDataItem(1, "group_id");
            var config = new FaceConfigurationSettings("123", LocationKeyIdentifier.AustraliaEast);
            var actual = config.GetAbsoluteUrlForApiAction(actionItem);
            Assert.Equal("https://australiaeast.api.cognitive.microsoft.com/face/v1.0/largepersongroups/group_id", actual);
        }

    }
}
