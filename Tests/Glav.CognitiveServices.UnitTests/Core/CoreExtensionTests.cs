using Xunit;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Extensions;

namespace Glav.CognitiveServices.UnitTests.Core
{
    public class CoreExtensionTests
    {

        [Fact]
        public void ShouldParseStringToUtcDateSuccessfully()
        {
            var testDate = "2018-10-15T11:51:27.6872495Z".ToUtc();
            Assert.Equal(2018, testDate.Year);
            Assert.Equal(10, testDate.Month);
            Assert.Equal(15, testDate.Day);
            Assert.Equal(11, testDate.Hour);
            Assert.Equal(51, testDate.Minute);
            Assert.Equal(27, testDate.Second);
        }

    }
}
