using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Core.Configuration
{
    public class ConfigurationSettings
    {
        public ConfigurationSettings()
        {
            Location = LocationKeys.WestUsa;
        }


        public ConfigurationSettings(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("APIKey cannot be empty");
            }
            Location = LocationKeys.WestUsa;
            ApiKey = apiKey;
        }

        public ConfigurationSettings(ConfigurationSettings settings)
        {
            this.ApiKey = settings.ApiKey;
            this.Location = settings.Location;
        }
        public string ApiKey { get; private set; }
        public string Location { get; private set; }
        public string BaseUrl
        {
            get
            {
                return string.Format(ApiServiceUrlFragments.BASE_URL_TEMPLATE, Location);
            }
        }
    }
}
