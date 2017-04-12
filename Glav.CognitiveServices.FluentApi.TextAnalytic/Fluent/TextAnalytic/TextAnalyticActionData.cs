using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Fluent.TextAnalytic
{
    public sealed class TextAnalyticActionData: IApiActionData
    {
        private List<TextAnalyticActionDataItem> _itemList = new List<TextAnalyticActionDataItem>();
        public void Add(ApiActionType apiType, string textToAnalyse, SupportedLanguageType language = SupportedLanguageType.English)
        {
            _itemList.Add(new TextAnalyticActionDataItem(_itemList.Count + 1, textToAnalyse, language, apiType));
        }
 
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{ \"documents\": [");
            _itemList.ForEach(i =>
            {
                builder.Append(i.ToString());
            });
            builder.Append("] }");
            return builder.ToString();
        }

        public TextAnalyticActionDataItem GetItemById(long id)
        {
            return _itemList.FirstOrDefault(i => i.Id == id);
        }

        public TextAnalyticActionDataItem[] GetAllItems()
        {
            return _itemList.ToArray();
        }
    }

    public sealed class TextAnalyticActionDataItem : IActionDataItem
    {
        public TextAnalyticActionDataItem(long id, string textToAnalyse, ApiActionType apiType)
        {
            Id = id;
            TextToAnalyse = textToAnalyse;
            Language = SupportedLanguageType.English;
            ApiType = apiType;
        }
        public TextAnalyticActionDataItem(long id, string textToAnalyse, SupportedLanguageType language, ApiActionType apiType)
        {
            Id = id;
            TextToAnalyse = textToAnalyse;
            Language = language;
            ApiType = apiType;
        }
        public long Id { get; private set; }
        public SupportedLanguageType Language { get; private set; }
        public ApiActionType ApiType { get; private set; }
        public string TextToAnalyse { get; private set; }

        public override string ToString()
        {
            return $"{{\"language\":\"{Language.ToCode()}\", \"id\":\"{Id.ToString()}\", \"text\":\"{TextToAnalyse}\"}}";
        }

    }
}
