using Glav.CognitiveServices.FluentApi.ComputerVision.Configuration;
using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class RecognizeTextAnalysisResultExtensions
    {
        public static IEnumerable<string> GetAllRecognisedText(this RecognizeTextAnalysisResult analysisResult)
        {
            var lines = analysisResult?.ResponseData?.recognitionResult?.lines.Select(l => l.text);
            return lines;
        }

    }
}
