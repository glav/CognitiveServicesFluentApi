
namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    public abstract class BaseApiServiceUriFragment
    {
        public const string BASE_URL_TEMPLATE = "https://{0}.api.cognitive.microsoft.com/";

        public abstract string Template { get;  }

        public abstract string Version { get; }

        public abstract ApiActionCategory ApiCategory { get; }

        public string ServiceUri
        {
            get
            {
                return string.Format(Template, Version);

            }
        }

    }
}
