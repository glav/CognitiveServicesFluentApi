using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain
{
    public sealed class TextAnalyticTopicActionData : IApiActionData
    {
        private List<string> _stopWords = new List<string>();
        private List<string> _topicsToExclude = new List<string>();
        private List<TextAnalyticTopicActionDataItem> _itemsList = new List<TextAnalyticTopicActionDataItem>();

        public void Add(string textToAnalyse)
        {
            _itemsList.Add(new TextAnalyticTopicActionDataItem(_itemsList.Count + 1, textToAnalyse));
        }
 
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{ ");
            builder.Append(" \"stopWords\": [");

            WriteStringArray(builder, _stopWords);

            builder.Append("],");

            builder.Append(" \"topicsToExclude\": [");
            WriteStringArray(builder, _topicsToExclude);
            builder.Append("], ");

            builder.Append("\"documents\": [");
            for (var cnt= 0; cnt < _itemsList.Count;cnt++)
            {
                if (cnt > 0) { builder.Append(","); }
                var item = _itemsList[cnt];
                builder.Append(item.ToString());
            };
            builder.Append("] }");
            return builder.ToString();
        }
        private void WriteStringArray(StringBuilder builder, List<string> listItems)
        {
            for (var index = 0; index < listItems.Count; index++)
            {
                if (index > 0) { builder.Append(","); }
                builder.Append($"\"{listItems[index]}\"");
            }

        }
    }


    public sealed class TextAnalyticTopicActionDataItem : IActionDataItem
    {
        public TextAnalyticTopicActionDataItem(long id, string textToAnalyse)
        {
            Id = id;
            TextToAnalyse = textToAnalyse;
            ApiType = ApiActionType.TextAnalyticsTopics;
        }
        public long Id { get; private set; }
        public ApiActionType ApiType { get; private set; }
        public string TextToAnalyse { get; private set; }

        public override string ToString()
        {
            return $"{{\"id\":\"{Id.ToString()}\", \"text\":\"{TextToAnalyse}\"}}";
        }

    }
}
