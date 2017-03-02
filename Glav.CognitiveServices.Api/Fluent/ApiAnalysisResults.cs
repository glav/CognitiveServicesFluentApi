using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public sealed class ApiAnalysisResults
    {
        public bool Successfull
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Error);
            }
        }
        public string Error { get; set; }
        public string SentimentResults { get; set; }
    }
}
