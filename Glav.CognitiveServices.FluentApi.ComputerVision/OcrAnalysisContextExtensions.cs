using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class OcrAnalysisContextExtensions
    {
        public static IEnumerable<string> GetAllWords(this OcrAnalysisContext context)
        {
            return context.AnalysisResults.SelectMany(r => r.ResponseData.regions)
                            .SelectMany(g => g.lines)
                            .SelectMany(l => l.words.Select(w => w.text));

        }

        public static SupportedLanguageItem LanguageDetected(this OcrAnalysisResult result)
        {
            return LanguageCodeParser.Parse(result.ResponseData.language);
        }

    }
}
