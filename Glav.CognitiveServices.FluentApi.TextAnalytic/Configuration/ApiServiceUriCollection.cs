using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection()
        {
            Services.Add(TextAnalyticApiOperations.SentimentAnalysis, new SentimentServiceConfig());
            Services.Add(TextAnalyticApiOperations.KeyPhraseAnalysis, new KeyPhraseServiceConfig());
            Services.Add(TextAnalyticApiOperations.LanguageAnalysis, new LanguageServiceConfig());
            Services.Add(TextAnalyticApiOperations.OperationStatus, new OperationStatusServiceConfig());
        }
    }
}
