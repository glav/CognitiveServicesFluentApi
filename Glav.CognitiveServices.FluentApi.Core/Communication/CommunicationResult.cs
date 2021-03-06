﻿using System;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Core.Communication
{
    public sealed class CommunicationResult : ICommunicationResult
    {
        private readonly HttpResponseMessage _httpResponse;

        private CommunicationResult()
        {

        }
        private CommunicationResult(HttpResponseMessage httpResponse)
        {
            _httpResponse = httpResponse;
        }

        private async Task AnalyseResponse()
        {
            if (_httpResponse == null)
            {
                Successfull = false;
                ErrorMessage = "No Data/Response";
                return;
            }

            Data = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
            StatusCode = _httpResponse.StatusCode;
            Successfull = _httpResponse.IsSuccessStatusCode;
            if (_httpResponse.Headers.Contains("x-aml-ta-request-id"))
            {
                RequestId = Guid.Parse(_httpResponse.Headers.GetValues("x-aml-ta-request-id").First());
            }
            if (_httpResponse.Headers.Contains("Operation-Location"))
            {
                OperationLocationUri = new Uri(_httpResponse.Headers.GetValues("Operation-Location").First());
            }
            if (_httpResponse.Headers.Contains("Location"))
            {
                LocationUri = new Uri(_httpResponse.Headers.GetValues("Location").First());
            }
            Ratelimit = new RequestRateLimitStatus(_httpResponse);
        }

        public Guid RequestId { get; private set; }
        public Uri OperationLocationUri { get; private set; }
        public Uri LocationUri { get; private set; }

        public bool Successfull { get; private set; }

        public string ErrorMessage { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }

        public string Data { get; private set; }

        public RequestRateLimitStatus Ratelimit { get; private set; }

        public static CommunicationResult Fail(string errorMessage)
        {
            return new CommunicationResult { Successfull = false, ErrorMessage = errorMessage };
        }

        public static async Task<CommunicationResult> ParseResultAsync(HttpResponseMessage httpResponse)
        {
            var result = new CommunicationResult(httpResponse);
            await result.AnalyseResponse();
            return result;
        }

    }

    public class RequestRateLimitStatus
    {
        public RequestRateLimitStatus()
        {

        }
        public RequestRateLimitStatus(HttpResponseMessage httpResponse)
        {
            if (httpResponse == null || (int)httpResponse.StatusCode != 429)
            {
                return;
            }
            Exceeded = true;
            RetryDelayInSeconds = httpResponse.Headers.RetryAfter.Delta.HasValue
                                    ? (long)httpResponse.Headers.RetryAfter.Delta.Value.TotalSeconds 
                                    : 0;
        }

        public bool Exceeded { get; }
        public long RetryDelayInSeconds { get; }
    }
}
