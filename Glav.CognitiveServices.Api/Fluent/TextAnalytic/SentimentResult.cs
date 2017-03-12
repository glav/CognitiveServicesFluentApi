using Glav.CognitiveServices.Api.Fluent.Contracts;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class SentimentResult : BaseDataCollection<SentimentResultResponseRoot>, IApiAnalysisResult
    {
        public SentimentResult()
        {
            Successfull = false;
        }
        public SentimentResult(string rawData)
        {
            RawResult = rawData;
            AddResultToCollection();
        }

        private void AddResultToCollection()
        {
            if (string.IsNullOrWhiteSpace(RawResult))
            {
                ItemList.Add(new SentimentResultResponseRoot { errors = new ApiErrorResponse[] { new ApiErrorResponse { id = 1, message = "No data returned." } } } );
                Successfull = false;
                return;
            }

            try
            {
                Result = Newtonsoft.Json.JsonConvert.DeserializeObject<SentimentResultResponseRoot>(RawResult);
                if (Result == null || Result.documents == null || Result.errors != null && Result.errors.Length > 0)
                {
                    Successfull = false;
                    return;
                }
                Successfull = true;
            } catch (Exception ex)
            {
                ItemList.Add(new SentimentResultResponseRoot { errors = new ApiErrorResponse[] { new ApiErrorResponse { id = 1, message = $"Error parsing results: {ex.Message}" } } });
                Successfull = false;
            }
        }

        // {"documents":[{"score":0.7988085,"id":"1"}],"errors":[]}
        public string RawResult { get; private set; }
        public bool Successfull { get; private set; }
        public SentimentResultResponseRoot Result { get; private set; }
    }


}
