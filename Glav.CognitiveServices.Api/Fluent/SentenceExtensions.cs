using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent
{
    public static class SentenceExtensions
    {
        public static IEnumerable<string> SplitTextIntoSentences(this string blobOfText)
        {
            if (string.IsNullOrWhiteSpace(blobOfText))
            {
                return new List<string>();
            }
            return blobOfText.Split(new char[] { '!', '.', '?' });
        }
    }
}
