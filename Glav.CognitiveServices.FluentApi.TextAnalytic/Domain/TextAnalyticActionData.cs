using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public sealed class TextAnalyticActionData: ApiActionDataCollection
    {
        public override bool SupportsBatchingMultipleItems => true;

        public void Add(ApiActionType apiType, string textToAnalyse, SupportedLanguageType language = SupportedLanguageType.English)
        {
            ItemList.Add(new TextAnalyticActionDataItem(ItemList.Count + 1, textToAnalyse, language, apiType));
        }
 
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{ \"documents\": [");
            ItemList.ForEach(i =>
            {
                var item = i as TextAnalyticActionDataItem;
                if (item.Id > 1) { builder.Append(","); }
                builder.Append(i.ToString());
            });
            builder.Append("] }");
            return builder.ToString();
        }

        public TextAnalyticActionDataItem GetItemById(long id)
        {
            return ItemList.FirstOrDefault(i => i.Id == id) as TextAnalyticActionDataItem;
        }

        public override string ToUrlQueryParameters()
        {
            return null;
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

        public bool IsBinaryData => false;

        public byte[] ToBinary()
        {
            return null;
        }

        public override string ToString()
        {
            return $"{{\"language\":\"{Language.ToCode()}\", \"id\":\"{Id.ToString()}\", \"text\":\"{TextToAnalyse}\"}}";
        }

        public string ToUrlQueryParameters()
        {
            return null;
        }
    }
}
