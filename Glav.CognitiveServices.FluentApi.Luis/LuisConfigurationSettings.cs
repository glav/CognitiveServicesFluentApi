using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Domain;

namespace Glav.CognitiveServices.FluentApi.Luis
{
    public class LuisConfigurationSettings : ConfigurationSettings
    {
        public const string APP_ID = "LuisAppId";
        public const string SUBSCRIPTION_KEY = "LuisSubscriptionKey";

        public bool ShowAllIntents {get; set;}
        public bool IsVerboseLoggingEnabled {get; set;}

        /// <summary>
        /// Luis is slightly different to other cognitive services in that instead of just an API Key, it requires an
        /// AppId (from Luis portal application settings) and a subscription Key (from Luid portal publish settings).
        /// </summary>
        public LuisConfigurationSettings(string appId, string subscriptionKey, LocationKeyIdentifier locationKey, 
            string apiVersionIdentifier = Configuration.ApiConstants.DEFAULT_LUIS_VERSION) 
                : base(LuisAnalysisApiOperations.Category,subscriptionKey, locationKey, new ApiServiceUriCollection(apiVersionIdentifier))
        {
            this.ApiKeys.Add(APP_ID, appId);
            this.ApiKeys.Add(SUBSCRIPTION_KEY, subscriptionKey);
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
        public static LuisConfigurationSettings CreateUsingConfigurationKeys(string appId, string subscriptionKey, LocationKeyIdentifier locationKey, string apiVersionIdentifier = Configuration.ApiConstants.DEFAULT_LUIS_VERSION)
        {
            return new LuisConfigurationSettings(appId, subscriptionKey,locationKey,apiVersionIdentifier);
        }
    }
}
