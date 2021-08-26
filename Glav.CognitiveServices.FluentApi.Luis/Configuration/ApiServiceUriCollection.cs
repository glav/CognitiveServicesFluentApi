using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Luis.Domain;

namespace Glav.CognitiveServices.FluentApi.Luis.Configuration
{
    public class ApiServiceUriCollection : ApiServiceUriCollectionBase
    {
        public ApiServiceUriCollection(string apiVersionIdentifier)
        {
            Services.Add(LuisAnalysisApiOperations.LuisAnalysis.Name,new LuisAppServiceConfig(apiVersionIdentifier));
        }
    }
}
