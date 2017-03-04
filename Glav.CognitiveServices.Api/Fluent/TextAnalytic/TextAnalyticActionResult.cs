using Glav.CognitiveServices.Api.Fluent.Contracts;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class TextAnalyticActionResult : BaseDataCollection<TextAnalyticActionResultResponseRoot>, IApiAnalysisResult
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
                ItemList.Add(new TextAnalyticActionResultResponseRoot { errors = new string[] { "No data returned." } });
                Successfull = false;
                return;
            }

            try
            {
                Result = Newtonsoft.Json.JsonConvert.DeserializeObject<TextAnalyticActionResultResponseRoot>(RawResult);
                if (Result.errors != null && Result.errors.Length > 0)
                {
                    Successfull = false;
                }
            } catch (Exception ex)
            {
                ItemList.Add(new TextAnalyticActionResultResponseRoot { errors = new string[] { $"Error parsing results: {ex.Message}" } });
                Successfull = false;
            }
        }

        // {"documents":[{"score":0.7988085,"id":"1"}],"errors":[]}
        public string RawResult { get; private set; }
        public bool Successfull { get; private set; }
        public TextAnalyticActionResultResponseRoot Result { get; private set; }
    }


}
