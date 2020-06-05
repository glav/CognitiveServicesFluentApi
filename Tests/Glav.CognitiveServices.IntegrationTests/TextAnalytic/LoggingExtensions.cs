using Glav.CognitiveServices.FluentApi.TextAnalytic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Glav.CognitiveServices.IntegrationTests.TextAnalytic
{
    public static class LoggingExtensions
    {
        public static void WriteVerboseResults(this TextAnalyticAnalysisResults result)
        {
            Trace.WriteLine("[LOG]***Begin***[LOG]");
            if (result == null)
            {
                Trace.WriteLine("[LOG] Results are NULL");
                return;
            }

            Trace.WriteLine(result.KeyPhraseAnalysis == null ? "KeyPhraseAnalysis is NULL" : "KeyPhraseAnalysis not NULL");
            Trace.WriteLine(result.LanguageAnalysis == null ? "LanguageAnalysis is NULL" : "LanguageAnalysis not NULL");
            Trace.WriteLine(result.SentimentAnalysis == null ? "SentimentAnalysis is NULL" : "SentimentAnalysis not NULL");

            Trace.WriteLine($"APICall ErrorMessage: {result.SentimentAnalysis?.AnalysisResult?.ApiCallResult?.ErrorMessage}");
            Trace.WriteLine($"APICall StatusCode: {result.SentimentAnalysis?.AnalysisResult?.ApiCallResult?.StatusCode}");

            Trace.WriteLine("[LOG]***End***[LOG]");
        }
    }
}
