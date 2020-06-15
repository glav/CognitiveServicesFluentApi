using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Luis.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Luis
{
    public class LuisAppAnalysisResults : IAnalysisResults
    {
        public LuisAppAnalysisResults(CoreAnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }

        public CoreAnalysisSettings AnalysisSettings { get; private set; }

        public LuisAppAnalysisContext LuisAppAnalysis { get; private set; }

        public void SetLuisAppResultContext(LuisAppAnalysisContext luisAppCtxt)
        {
            LuisAppAnalysis = luisAppCtxt ?? throw new ArgumentNullException("luisAppCtxt");

        }

        public void AddImageAnalysisResult(ApiActionDataCollection actionData, ICommunicationResult commsResult)
        {
            if (LuisAppAnalysis == null)
            {
                LuisAppAnalysis = new LuisAppAnalysisContext(actionData, new LuisAppAnalysisResult(commsResult), AnalysisSettings.ConfigurationSettings.GlobalScoringEngine);
                return;
            }
            LuisAppAnalysis.AnalysisResults.Add(new LuisAppAnalysisResult(commsResult));

        }
    }
}
