
namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    public abstract class ApiServiceUriFragment
    {

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
