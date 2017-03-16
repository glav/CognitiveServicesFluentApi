﻿using Glav.CognitiveServices.Api.Http;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic.Responses;
using System;

namespace Glav.CognitiveServices.Api.Fluent.TextAnalytic
{
    public sealed class LanguagesResult : BaseResponseResult<LanguagesResultResponseRoot>
    {
        public LanguagesResult()
        {
            Successfull = false;
        }
        public LanguagesResult(HttpResult apiCallResult)
        {
            ApiCallResult = apiCallResult;
            AddResultToCollection();
        }

        private void AddResultToCollection()
        {
            if (ApiCallResult == null)
            {
                ItemList.Add(new LanguagesResultResponseRoot { errors = new ApiErrorResponse[] { new ApiErrorResponse { id = 1, message = "No data returned." } } } );
                Successfull = false;
                return;
            }

            try
            {
                ResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject<LanguagesResultResponseRoot>(ApiCallResult.Data);
                if (ResponseData == null || ResponseData.documents == null || ResponseData.errors != null && ResponseData.errors.Length > 0)
                {
                    Successfull = false;
                    return;
                }
                Successfull = true;
            } catch (Exception ex)
            {
                ItemList.Add(new LanguagesResultResponseRoot { errors = new ApiErrorResponse[] { new ApiErrorResponse { id = 1, message = $"Error parsing results: {ex.Message}" } } });
                Successfull = false;
            }
        }

    }


}
