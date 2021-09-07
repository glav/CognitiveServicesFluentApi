using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection(string apiVersionIdentifier)
        {
            Services.Add(TextAnalyticApiOperations.SentimentAnalysis.Name, new SentimentServiceConfig(apiVersionIdentifier));
            Services.Add(TextAnalyticApiOperations.KeyPhraseAnalysis.Name, new KeyPhraseServiceConfig(apiVersionIdentifier));
            Services.Add(TextAnalyticApiOperations.LanguageAnalysis.Name, new LanguageServiceConfig(apiVersionIdentifier));
            Services.Add(TextAnalyticApiOperations.OperationStatus.Name, new OperationStatusServiceConfig(apiVersionIdentifier));
        }
    }
}
