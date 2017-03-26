namespace Glav.CognitiveServices.Api.Configuration.TextAnalytic
{
        public class KeyPhraseServiceConfig : BaseApiServiceUriFragment
        {
            public KeyPhraseServiceConfig()
            {
                Version = TEXT_ANALYTIC_VERSION;
                Template = "text/analytics/{0}/keyPhrases";
            }

        }
}
