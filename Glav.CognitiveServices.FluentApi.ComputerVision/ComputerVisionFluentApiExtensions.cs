using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class ComputerVisionFluentApiExtensions
    {
        public static async Task<ComputerVisionAnalysisResults> AnalyseAllAsync(this ImageAnalysisSettings apiAnalysisSettings)
        {
            var engine = new ComputerVisionAnalysisEngine(apiAnalysisSettings);
            return await engine.AnalyseAllAsync();
        }
    }
}
