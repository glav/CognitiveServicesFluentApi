using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    public abstract class ConfigurationSettings
    {

        public ConfigurationSettings(string apiKey, ApiServiceUrlFragmentsBase serviceUrls)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("APIKey cannot be empty");
            }
            LocationKey = LocationKeys.WestUsa;
            ApiKey = apiKey;
            ServiceUrls = serviceUrls;
        }

        public ConfigurationSettings(ConfigurationSettings settings)
        {
            this.ApiKey = settings.ApiKey;
            this.LocationKey = settings.LocationKey;
            this.ServiceUrls = settings.ServiceUrls;
        }
        public string ApiKey { get; protected set; }
        public string LocationKey { get; protected set; }
        public ApiServiceUrlFragmentsBase ServiceUrls { get; protected set; }
        public string BaseUrl
        {
            get
            {
                return string.Format(ApiServiceUrlFragmentsBase.BASE_URL_TEMPLATE, LocationKey);
            }
        }
    }
}
