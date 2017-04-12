using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    public class ApiServiceUrlFragmentsBase
    {
        public const string BASE_URL_TEMPLATE = "https://{0}.api.cognitive.microsoft.com/";
        private Dictionary<ApiActionType, BaseApiServiceUriFragment> _services = new Dictionary<ApiActionType, BaseApiServiceUriFragment>();

        protected Dictionary<ApiActionType, BaseApiServiceUriFragment> Services => _services;

        public BaseApiServiceUriFragment GetServiceConfig(ApiActionType apiAction)
        {
            return Services[apiAction];
        }
    }
}
