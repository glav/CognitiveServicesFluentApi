using Glav.CognitiveServices.Api.Fluent;
using Glav.CognitiveServices.Api.Configuration;
using System;
using Xunit;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;

namespace Glav.CognitiveServices.UnitTests
{
    public class ParsingTests
    {
        [Fact]
        public void TextAnalyticParseResult()
        {
            var input = "{\"documents\":[{\"score\":0.7988085,\"id\":\"1\"}],\"errors\":[]}";
            var result = new TextAnalyticActionResult(input);
        }
    }
}
