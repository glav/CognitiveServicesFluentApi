using Glav.CognitiveServices.FluentApi.ComputerVision.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    public static class ReadImageAnalysisResultExtensions
    {
        public static IEnumerable<string> GetAllRecognisedText(this ReadImageAnalysisResult analysisResult)
        {
            var lines = analysisResult?.ResponseData?.analyzeResult?.readResults?.SelectMany(l => l.lines.Select(w => w.text));
            return lines;
        }
        public static IEnumerable<string> GetAllRecognisedWords(this ReadImageAnalysisResult analysisResult)
        {
            var lineItems = analysisResult?.ResponseData?.analyzeResult?.readResults?.SelectMany(l => l.lines);
            var words = lineItems.SelectMany(l => l.words).Select(w => w.text);
            return words;
        }

    }
}
