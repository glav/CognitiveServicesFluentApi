using Glav.CognitiveServices.Api.Fluent.Contracts;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class TopicResult : BaseDataCollection<KeyPhraseResultResponseRoot>, IApiAnalysisResult
    {
        public TopicResult()
        {
            Successfull = false;
        }
        public TopicResult(string rawData)
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
                if (Result ==null || Result.documents == null|| Result.errors != null && Result.errors.Length > 0)
                {
                    Successfull = false;
                    if (Result == null || Result.documents == null)
                    {
                        ItemList.Add(new KeyPhraseResultResponseRoot { errors = new ApiErrorResponse[] { new ApiErrorResponse { id = 1, message = "Bad request. Probably badly formatted request." } } });
                    }
                    return;
                }
                Successfull = true;
            } catch (Exception ex)
            {
                ItemList.Add(new KeyPhraseResultResponseRoot { errors = new ApiErrorResponse[] { new ApiErrorResponse { id = 1, message = $"Error parsing results: {ex.Message}" } } });
                Successfull = false;
            }
        }

        public string RawResult { get; private set; }
        public bool Successfull { get; private set; }
        public KeyPhraseResultResponseRoot Result { get; private set; }
    }


}
