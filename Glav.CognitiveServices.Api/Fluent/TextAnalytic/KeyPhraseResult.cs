using Glav.CognitiveServices.Api.Fluent.Contracts;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class KeyPhraseResult : BaseDataCollection<KeyPhraseResultResponseRoot>, IApiAnalysisResult
    {
        public KeyPhraseResult()
        {
            Successfull = false;
        }
        public KeyPhraseResult(string rawData)
        {
            RawResult = rawData;
            AddResultToCollection();
        }

        private void AddResultToCollection()
        {
            if (string.IsNullOrWhiteSpace(RawResult))
            {
                ItemList.Add(new KeyPhraseResultResponseRoot { errors = new ApiErrorResponse[] { new ApiErrorResponse { id = 1, message = "No data returned." } } });
                Successfull = false;
                return;
            }

            try
            {
                Result = Newtonsoft.Json.JsonConvert.DeserializeObject<KeyPhraseResultResponseRoot>(RawResult);
                if (Result.errors != null && Result.errors.Length > 0)
                {
                    Successfull = false;
                }
                Successfull = true;
            } catch (Exception ex)
            {
                ItemList.Add(new KeyPhraseResultResponseRoot { errors = new ApiErrorResponse[] { new ApiErrorResponse { id = 1, message = $"Error parsing results: {ex.Message}" } } });
                Successfull = false;
            }
        }

        // {"documents":[{"score":0.7988085,"id":"1"}],"errors":[]}
        public string RawResult { get; private set; }
        public bool Successfull { get; private set; }
        public KeyPhraseResultResponseRoot Result { get; private set; }
    }


}
