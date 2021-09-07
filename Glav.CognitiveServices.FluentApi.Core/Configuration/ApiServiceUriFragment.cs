
namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    public abstract class ApiServiceUriFragment
    {
        private string _apiVersionIdentifier;
        public ApiServiceUriFragment(string apiVersionIdentifier)
        {
            if (string.IsNullOrWhiteSpace(apiVersionIdentifier))
            {
                throw new FluentApi.Core.CognitiveServicesException("API Version identifier must be specified. eg. V3.0");
            }
            _apiVersionIdentifier = apiVersionIdentifier;
        }

        public abstract string Template { get;  }

        public virtual string Version { get { return _apiVersionIdentifier; } }

        public abstract ApiActionDefinition ApiAction { get; }

        public string ServiceUri
        {
            get
            {
                return string.Format(Template, Version);

            }
        }

    }
}
