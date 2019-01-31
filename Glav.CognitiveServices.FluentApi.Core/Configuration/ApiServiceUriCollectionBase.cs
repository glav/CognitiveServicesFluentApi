using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    public class ApiServiceUriCollectionBase
    {
        public const string BASE_URL_TEMPLATE = "https://{0}api.cognitive.microsoft.com/";
        private readonly Dictionary<ApiActionDefinition, ApiServiceUriFragment> _services = new Dictionary<ApiActionDefinition, ApiServiceUriFragment>();

        protected Dictionary<ApiActionDefinition, ApiServiceUriFragment> Services => _services;

        public ApiServiceUriFragment GetServiceConfig(ApiActionDefinition apiAction)
        {
            return Services[apiAction];
        }
    }
}
