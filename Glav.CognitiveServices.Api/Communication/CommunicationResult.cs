using System;
using System.Net;
using System.Net.Http;
using System.Linq;

namespace Glav.CognitiveServices.Api.Communication
{
    public sealed class CommunicationResult
    {
        private readonly HttpResponseMessage _httpResponse;

        private CommunicationResult()
        {

        }
        public CommunicationResult(HttpResponseMessage httpResponse)
        {
            _httpResponse = httpResponse;
            AnalyseResponse();
        }

        private async void AnalyseResponse()
        {
            if (_httpResponse == null)
            {
                Successfull = false;
                ErrorMessage = "No Data/Response";
            }

            Data = await _httpResponse.Content.ReadAsStringAsync();
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
        }

        public Guid RequestId { get; private set; }
        public Uri OperationLocationUri { get; private set; }
        public Uri LocationUri { get; private set; }

        public bool Successfull { get; private set; }

        public string ErrorMessage { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }

        public string Data { get; private set; }

        public static CommunicationResult Fail(string errorMessage)
        {
            return new CommunicationResult { Successfull = false, ErrorMessage = errorMessage };
        }

    }
}
