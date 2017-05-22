using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public static class SentenceExtensions
    {
        // Pretty simplistic sentence separation with no idea of different languages but its a start.
        public static readonly char[] DefaultSentenceSplitCharacters = { '!', '.', '?' };

        public static IEnumerable<string> SplitTextIntoSentences(this string blobOfText, char[] charactersToSplitSentences = null)
        {
            if (string.IsNullOrWhiteSpace(blobOfText))
            {
                return new List<string>();
            }
            if (charactersToSplitSentences == null)
            {
                charactersToSplitSentences = DefaultSentenceSplitCharacters;
            }
            return blobOfText.Split(charactersToSplitSentences);
        }

    }
}
