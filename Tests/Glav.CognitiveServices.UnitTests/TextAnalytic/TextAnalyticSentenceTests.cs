using Xunit;
using Glav.CognitiveServices.FluentApi.TextAnalytic;
using System;
using System.Collections.Generic;
using System.Linq;
using Glav.CognitiveServices.UnitTests.Helpers;

namespace Glav.CognitiveServices.UnitTests.TextAnalytic
{
    public class TextAnalyticSentenceTests
    {
        private TestDataHelper _helper = new TestDataHelper();
        [Fact]
        public void ShouldSplitIntoSentences()
        {
            var blobOfText = _helper.GetFileDataEmbeddedInAssembly("SanitisedHtmlEmail.txt");
            var sentences = blobOfText.SplitTextIntoSentences();
            Assert.NotNull(sentences);

            var sentenceList = sentences.ToList();
            Assert.False(sentenceList.Any(s => string.IsNullOrWhiteSpace(s)));
            Assert.False(sentenceList.Any(s => s.Contains("\n") || (s.Contains("\r"))));
            Assert.False(sentenceList.Any(s => s.Length <= 2));

            Assert.True(sentenceList.Count() > 0);
        }

    }
}
