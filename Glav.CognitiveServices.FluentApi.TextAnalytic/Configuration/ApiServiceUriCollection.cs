using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection()
        {
            Services.Add(TextAnalyticApiOperations.SentimentAnalysis.Name, new SentimentServiceConfig());
            Services.Add(TextAnalyticApiOperations.KeyPhraseAnalysis.Name, new KeyPhraseServiceConfig());
            Services.Add(TextAnalyticApiOperations.LanguageAnalysis.Name, new LanguageServiceConfig());
            Services.Add(TextAnalyticApiOperations.OperationStatus.Name, new OperationStatusServiceConfig());
        }
    }
}
