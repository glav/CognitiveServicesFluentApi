using System.Collections.Generic;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    /// <summary>
    /// Text analytic analysis can often work better in smaller chunks of text such as sentences so have provided this convenience menthod
    /// to do just that.
    /// </summary>
    public static class SentenceExtensions
    {
        // Pretty simplistic sentence separation with no idea of different languages but its a start.
        private static readonly char[] DefaultSentenceSplitCharacters = { '!', '.', '?' };

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
            var splitText = blobOfText.Split(charactersToSplitSentences);

            // We may have elements that are either empty, whitespace or just junk so lets remove them.
            var splitTextRemovedCrLf = splitText
                .Select(s =>
                    s.Replace("\n", string.Empty)
                    .Replace("\r", string.Empty));

            var splitTextNonEmpty = splitTextRemovedCrLf
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Where(s => s.Length > 2);
            return splitTextNonEmpty;
        }

    }
}
