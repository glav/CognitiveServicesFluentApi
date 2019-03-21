using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Core.Communication
{
    internal class HttpCommunicationEngine : ICommunicationEngine
    {
        private readonly ConfigurationSettings _configurationSettings;

        public HttpCommunicationEngine(ConfigurationSettings configurationSettings)
        {
            _configurationSettings = configurationSettings;
        }
        private static HttpClient CreateHttpClient(string apiKey)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add(HttpHeaders.SubscriptionKey, apiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HttpHeaders.MediaTypeApplicationJson));
            return client;
        }

        /// <summary>
        /// The main method of communicating with the cognitive service APIs with support for POST, PUT and GET
        /// </summary>
        /// <param name="apiActionType"></param>
        /// <param name="content"></param>
        /// <param name="urlQueryParameters"></param>
        /// <returns></returns>
        public async Task<ICommunicationResult> CallServiceAsync(IActionDataItem actionItem)
        {
            _configurationSettings.DiagnosticLogger.LogInfo($"Performing async service call for {actionItem.ApiDefintition}", "HttpCommunicationEngine");
            ByteArrayContent content = null;
            if (actionItem.IsBinaryData)
            {
                content = new ByteArrayContent(actionItem.ToBinary());
                content.Headers.ContentType = new MediaTypeHeaderValue(HttpHeaders.MediaTypeApplicationOctetStream);
            }
            else
            {
                // Only setup content if the operation is NOT a Http GET
                content = actionItem.ApiDefintition.Method != HttpMethod.Get ?
                    new StringContent(actionItem.ToString(), System.Text.Encoding.UTF8, HttpHeaders.MediaTypeApplicationJson) :
                    null;
            }

            var url = _configurationSettings.GetAbsoluteUrlForApiAction(actionItem);
            return await CallServiceInternal(url,actionItem.ApiDefintition.Method, content,actionItem.ApiDefintition.Category);

        }

        private async Task<ICommunicationResult> CallServiceInternal(string url, HttpMethod apiHttpMethod, ByteArrayContent content, string apiCategory)
        {
            try
            {
                ICommunicationResult commsResult = null;

                using (var httpClient = HttpCommunicationEngine.CreateHttpClient(_configurationSettings.ApiKeys[apiCategory]))
                {
                    int retryCount = 0;
                    const int maxRetries = 3;
                    while (retryCount < maxRetries)
                    {
                        HttpResponseMessage httpResult = null;
                        if (apiHttpMethod == HttpMethod.Put)
                        {
                            httpResult = await httpClient.PutAsync(url, content).ConfigureAwait(continueOnCapturedContext: false);

                        }
                        if (apiHttpMethod == HttpMethod.Post)
                        {
                            httpResult = await httpClient.PostAsync(url, content).ConfigureAwait(continueOnCapturedContext: false);
                        }
                        if (apiHttpMethod == HttpMethod.Get)
                        {
                            httpResult = await httpClient.GetAsync(url).ConfigureAwait(continueOnCapturedContext: false);
                        }
                        if (apiHttpMethod == HttpMethod.Options || apiHttpMethod == HttpMethod.Delete)
                        {
                            throw new MissingMethodException($"HTTP Method {apiHttpMethod} not currently supported.");
                        }
                        commsResult = await CommunicationResult.ParseResultAsync(httpResult);
                        if (!commsResult.Ratelimit.Exceeded)
                        {
                            return commsResult;
                        }
                        retryCount++;
                        _configurationSettings.DiagnosticLogger.LogWarning($"Retrying operation, waiting {commsResult.Ratelimit.RetryDelayInSeconds} seconds ");
                        await System.Threading.Tasks.Task.Delay(((int)commsResult.Ratelimit.RetryDelayInSeconds * 1000));
                    }
                    // If we get here, then we have tried too many times so just return the last result
                    _configurationSettings.DiagnosticLogger.LogError($"Too many retries (#{retryCount}), aborting.");
                    return commsResult;
                }
            }
            catch (Exception ex)
            {
                _configurationSettings.DiagnosticLogger.LogError(ex, "HttpCommunicationEngine");
                return CommunicationResult.Fail(ex.Message);
            }
        }

        public async Task<ICommunicationResult> CallBatchServiceAsync(ApiActionDataCollection actionItemCollection)
        {
            var urlQueryParams = actionItemCollection.ToUrlQueryParameters();
            var payload = actionItemCollection.ToString();
            var firstAction = actionItemCollection.GetAllItems().First();
            var url = _configurationSettings.GetAbsoluteUrlForApiAction(firstAction);
            var content = new StringContent(actionItemCollection.ToString(), System.Text.Encoding.UTF8, HttpHeaders.MediaTypeApplicationJson);
            return await CallServiceInternal(url, firstAction.ApiDefintition.Method, content, firstAction.ApiDefintition.Category);
        }

        /// <summary>
        /// This method is provided mostly to facilitate the OperationStatus call which only provides a simple API
        /// endpoint in response to one of the main cognitive service calls to check on an operations status.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<ICommunicationResult> ServiceGetAsync(string uri, string category)
        {
            try
            {
                using (var httpClient = HttpCommunicationEngine.CreateHttpClient(_configurationSettings.ApiKeys[category]))
                {
                    var httpResult = await httpClient.GetAsync(uri).ConfigureAwait(continueOnCapturedContext: false);
                    return await CommunicationResult.ParseResultAsync(httpResult);
                }
            }
            catch (Exception ex)
            {
                return CommunicationResult.Fail(ex.Message);
            }
        }

    }
}
