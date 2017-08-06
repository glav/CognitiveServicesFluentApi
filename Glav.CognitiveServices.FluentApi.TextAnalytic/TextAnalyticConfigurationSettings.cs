using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public class TextAnalyticConfigurationSettings : ConfigurationSettings
    {
        public TextAnalyticConfigurationSettings(string apiKey, LocationKeyIdentifier locationKey) 
                : base(ApiActionCategory.TextAnalytics,apiKey, locationKey, new ApiServiceUriCollection())
        {
        }

        public TextAnalyticConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        public static TextAnalyticConfigurationSettings CreateUsingConfigurationKeys(string apiKey, LocationKeyIdentifier locationKey)
        {
            return new TextAnalyticConfigurationSettings(apiKey,locationKey);
        }
    }
}
