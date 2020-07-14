using Glav.CognitiveServices.FluentApi.Luis.Domain;
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
    }
}
