using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Domain;

namespace Glav.CognitiveServices.FluentApi.Luis
{
    public class LuisConfigurationSettings : ConfigurationSettings
    {
        public const string APP_ID = "LuisAppId";

        public bool ShowAllIntents {get; set;}
        public bool IsVerboseLoggingEnabled {get; set;}

        /// <summary>
        /// Luis is slightly different to other cognitive services in that instead of just an API Key, it requires an
        /// AppId (from Luis portal application settings) and a subscription Key (from Luid portal publish settings).
        /// </summary>
        LuisConfigurationSettings(string appId, string subscriptionKey, LocationKeyIdentifier locationKey) 
                : base(LuisAnalysisApiOperations.Category,subscriptionKey, locationKey, new ApiServiceUriCollection())
        {
            this.ApiKeys.Add(APP_ID, appId);
            ShowAllIntents = true;
            IsVerboseLoggingEnabled = true;
        }

        public LuisConfigurationSettings(ConfigurationSettings settings) : base(settings)
        {
        }

        /// <summary>
        /// Luis is slightly different to other cognitive services in that instead of just an API Key, it requires an
        /// AppId (from Luis portal application settings) and a subscription Key (from Luid portal publish settings).
        /// </summary>
        public static LuisConfigurationSettings CreateUsingConfigurationKeys(string appId, string subscriptionKey, LocationKeyIdentifier locationKey)
        {
            return new LuisConfigurationSettings(appId, subscriptionKey,locationKey);
        }
    }
}
