using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class TextAnalyticActionData: IApiActionData
    {
        private List<TextAnalyticActionDataItem> _items = new List<TextAnalyticActionDataItem>();

        public void Add(string textToAnalyse, SupportedLanguage language = SupportedLanguage.English)
        {
            _items.Add(new TextAnalyticActionDataItem(_items.Count + 1, textToAnalyse, language));
        }

        public IEnumerable<TextAnalyticActionDataItem> AllItems()
        {
            return _items.ToArray();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{ \"documents\": [");
            _items.ForEach(i =>
            {
                builder.Append(i.ToString());
            });
            builder.Append("] }");
            return builder.ToString();
        }
    }

    public sealed class TextAnalyticActionDataItem
    {
        public TextAnalyticActionDataItem(long id, string textToAnalyse)
        {
            Id = id;
            TextToAnalyse = textToAnalyse;
            Language = SupportedLanguage.English;
        }
        public TextAnalyticActionDataItem(long id, string textToAnalyse, SupportedLanguage language)
        {
            Id = id;
            TextToAnalyse = textToAnalyse;
            Language = language;
        }
        public long Id { get; private set; }
        public SupportedLanguage Language { get; private set; }
        public string TextToAnalyse { get; private set; }

        public override string ToString()
        {
            return $"{{\"language\":\"{Language.ToLanguageCode()}\", \"id\":\"{Id.ToString()}\", \"text\":\"{TextToAnalyse}\"}}";
        }

    }
}
