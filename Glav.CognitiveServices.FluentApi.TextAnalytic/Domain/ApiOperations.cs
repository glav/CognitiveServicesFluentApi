using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public static class TextAnalyticApiOperations
    {
        public const string Category = "TextAnalytic";
        static TextAnalyticApiOperations()
        {
            SentimentAnalysis = new SentimentAnalysisApiOperation();
        }
        public static SentimentAnalysisApiOperation SentimentAnalysis { get; }
        public static LanguageAnalysisApiOperation LanguageAnalysis { get; }
        public static KeyPhraseAnalysisApiOperation KeyPhraseAnalysis { get; }
        public static OperationStatusApiOperation OperationStatus { get; }

    }

    

    public class SentimentAnalysisApiOperation : ApiActionDefinition
    {
        public SentimentAnalysisApiOperation() : base(HttpMethod.Post, TextAnalyticApiOperations.Category)
        {
        }
    }
    public class LanguageAnalysisApiOperation : ApiActionDefinition
    {
        public LanguageAnalysisApiOperation() : base(HttpMethod.Post, TextAnalyticApiOperations.Category)
        {
        }
    }
    public class KeyPhraseAnalysisApiOperation : ApiActionDefinition
    {
        public KeyPhraseAnalysisApiOperation() : base(HttpMethod.Post, TextAnalyticApiOperations.Category)
        {
        }
    }
    public class OperationStatusApiOperation : ApiActionDefinition
    {
        public OperationStatusApiOperation() : base(HttpMethod.Post, TextAnalyticApiOperations.Category)
        {
        }
    }
}
