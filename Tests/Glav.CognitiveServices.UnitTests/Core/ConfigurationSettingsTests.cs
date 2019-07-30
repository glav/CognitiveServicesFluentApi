using Xunit;
using Glav.CognitiveServices.UnitTests.Helpers;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Extensions;
using Glav.CognitiveServices.FluentApi.Core.Configuration;

namespace Glav.CognitiveServices.UnitTests.Core
{
    public class ConfigurationSettingsTests
    {

        [Fact]
        public void ConfigShouldOutputCurrentSettings()
        {
            var config = new TestConfig("apiCategory", "apiKey", LocationKeyIdentifier.AustraliaEast, null)
                .SetDiagnosticLoggingLevel(LoggingLevel.ErrorsOnly)
                .AddConsoleAndTraceLogging();
            var output = config.ToString();

            Assert.NotNull(output);
            Assert.Contains("LogLevel: ErrorsOnly", output);
            Assert.Contains("LocationKey: AustraliaEast", output);
            Assert.Contains("MaxNumberOfRequestRetries: 3", output);

        }

    }

    public class TestConfig : ConfigurationSettings
    {
        public TestConfig(ConfigurationSettings settings) : base(settings)
        {
        }

        public TestConfig(string apiCategory, string apiKey, LocationKeyIdentifier locationKey,
                    ApiServiceUriCollectionBase serviceUris) : base(apiCategory,apiKey,locationKey,serviceUris)
        {

        }
    }
}
