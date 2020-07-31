using Glav.CognitiveServices.FluentApi.Luis.Domain;
using Glav.CognitiveServices.FluentApi.Luis.Domain.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Luis
{
    public static class LuisAppAnalysisContextExtensions
    {
        public static IEnumerable<string> GetTopIntents(this LuisAppAnalysisContext analysisContext)
        {
            return analysisContext.AnalysisResults.Select(i => i.ResponseData?.prediction?.topIntent);
        }

        public static IEnumerable<LuisAppEntity> GetEntities(this LuisAppAnalysisContext analysisContext)
        {
            return analysisContext.AnalysisResults.SelectMany(i => i.ResponseData?.prediction?.entityInstanceList?.entityIdentifiers);
        }

        public static IEnumerable<LuisAppIntent> GetIntents(this LuisAppAnalysisContext analysisContext)
        {
            return analysisContext.AnalysisResults.SelectMany(i => i.ResponseData?.prediction?.intents);
        }
    }
}
