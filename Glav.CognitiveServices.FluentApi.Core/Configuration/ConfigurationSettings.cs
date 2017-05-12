using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    public abstract class ConfigurationSettings
    {
        private Dictionary<ApiActionCategory, string> _apiKeys = new Dictionary<ApiActionCategory, string>();
        protected ConfigurationSettings()
        {

        }

        public ConfigurationSettings(ApiActionCategory apiCategory, string apiKey, LocationKeyIdentifier locationKey, ApiServiceUrlFragmentsBase serviceUrls)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("APIKey cannot be empty");
            }
            LocationKey = locationKey;
            _apiKeys.Add(apiCategory, apiKey);
            ServiceUrls = serviceUrls;
        }

        public ConfigurationSettings(ConfigurationSettings settings)
        {
            _apiKeys = settings.ApiKeys;
            this.LocationKey = settings.LocationKey;
            this.ServiceUrls = settings.ServiceUrls;
        }
        public Dictionary<ApiActionCategory, string> ApiKeys => _apiKeys;
        public LocationKeyIdentifier LocationKey { get; protected set; }
        public ApiServiceUrlFragmentsBase ServiceUrls { get; protected set; }
        public string BaseUrl
        {
            get
            {
                return string.Format(ApiServiceUrlFragmentsBase.BASE_URL_TEMPLATE, LocationKey.ToTextLocation());
            }
        }
    }
}
