using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text; 
using Glav.CognitiveServices.FluentApi.Core;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Emotion
{
    public class EmotionAnalysisEngine : IAnalysisEngine<EmotionAnalysisResults>
    {
        public EmotionAnalysisEngine(AnalysisSettings analysisSettings)
        {
            AnalysisSettings = analysisSettings;
        }
        public AnalysisSettings AnalysisSettings { get; private set; }

        public Task<EmotionAnalysisResults> AnalyseAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
