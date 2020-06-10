using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Domain;

namespace Glav.CognitiveServices.FluentApi.Luis
{
    public class LuisConfigurationSettings : ConfigurationSettings
    {
        public LuisConfigurationSettings(string apiKey, LocationKeyIdentifier locationKey) 
                : base(LuisAnalysisApiOperations.Category,apiKey, locationKey, new ApiServiceUriCollection())
        {
        }

        public LuisConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        public static LuisConfigurationSettings CreateUsingConfigurationKeys(string apiKey, LocationKeyIdentifier locationKey)
        {
            return new LuisConfigurationSettings(apiKey,locationKey);
        }
    }
}
