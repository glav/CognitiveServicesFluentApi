
namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    public class BaseApiServiceUriFragment
    {
        public const string BASE_URL_TEMPLATE = "https://{0}.api.cognitive.microsoft.com/";

        public string Template { get; protected set; }

        public string Version { get; set; }

        public string ServiceUri
        {
            get
            {
                return string.Format(Template, Version);

            }
        }

    }
}
