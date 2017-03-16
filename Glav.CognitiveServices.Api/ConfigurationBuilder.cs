using Glav.CognitiveServices.Api.Configuration;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.Api
{
    public static class ConfigurationBuilder
    {
        public static ApiAnalysisSettings CreateUsingApiKey(string apiKey)
        {
            var config = new ConfigurationSettings(apiKey);
            return new ApiAnalysisSettings(config);
        }

        public static Task<ApiAnalysisResults> AnalyseAllAsync(this ApiAnalysisSettings apiAnalysisSettings)
        {
            return new AnalysisEngine(apiAnalysisSettings).AnalyseAllAsync();
        }
    }
}
