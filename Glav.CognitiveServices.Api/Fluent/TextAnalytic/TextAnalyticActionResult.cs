using Glav.CognitiveServices.Api.Fluent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class TextAnalyticActionResult : BaseDataCollection<TextAnalyticActionResultItemContainer>, IApiAnalysisResultData
    {
        public TextAnalyticActionResult(string rawData)
        {
            RawResult = rawData;
            AddResultToCollection();
        }

        private void AddResultToCollection()
        {
            if (string.IsNullOrWhiteSpace(RawResult))
            {
                ItemList.Add(new TextAnalyticActionResultItemContainer { errors = new string[] { "No data returned." } });
                Successfull = false;
                return;
            }

            try
            {
                Result = Newtonsoft.Json.JsonConvert.DeserializeObject<TextAnalyticActionResultItemContainer>(RawResult);
                if (Result.errors != null && Result.errors.Length > 0)
                {
                    Successfull = false;
                }
            } catch (Exception ex)
            {
                ItemList.Add(new TextAnalyticActionResultItemContainer { errors = new string[] { $"Error parsing results: {ex.Message}" } });
                Successfull = false;
            }
        }

        // {"documents":[{"score":0.7988085,"id":"1"}],"errors":[]}
        public string RawResult { get; private set; }
        public bool Successfull { get; private set; }
        public TextAnalyticActionResultItemContainer Result { get; private set; }
    }

    public sealed class TextAnalyticActionResultItemContainer : IActionDataItem
    {
        public TextAnalyticActionResultItem[] documents { get; set; }
        public string[] errors { get; set; }
    }

    public sealed class TextAnalyticActionResultItem
    {
        public long id { get; set; }
        public double score { get; set; }
    }
}
