using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Luis.Domain
{
    public static class LuisAnalysisApiOperations
    {
        public const string Category = "Luis";
        static LuisAnalysisApiOperations()
        {
            LuisAnalysis = new LuisAnalysisApiOperation();
        }
        public static LuisAnalysisApiOperation LuisAnalysis { get; }

    }

    

    public class LuisAnalysisApiOperation : ApiActionDefinition
    {
        public LuisAnalysisApiOperation() : base(HttpMethod.Get, LuisAnalysisApiOperations.Category)
        {
        }
    }
}
