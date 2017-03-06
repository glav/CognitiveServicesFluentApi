using Glav.CognitiveServices.Api.Configuration;
using Glav.CognitiveServices.Api.Fluent.Contracts;
using Glav.CognitiveServices.Api.Fluent.Http;
using Glav.CognitiveServices.Api.Fluent.TextAnalytic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.Api.Fluent
{
    public sealed class AnalysisEngine
    {
        private readonly ApiAnalysisSettings _analysisSettings;

        public AnalysisEngine(ApiAnalysisSettings analysisSettings)
        {
            _analysisSettings = analysisSettings;
        }

        public ApiAnalysisSettings AnalysisSettings { get { return _analysisSettings; } }

        public async Task<ApiAnalysisResults> ExecuteAllAsync()
        {
            var apiResults = new ApiAnalysisResults();
            var sentiments = _analysisSettings.ActionsToPerform.Where(a => a.ActionType == Configuration.ApiActionType.TextAnalyticsSentiment).ToList();
            if (sentiments.Count > 0)
            {
                var apiAction = sentiments.First() as TextAnalyticApiAction;
                var payload = apiAction.ActionData<TextAnalyticActionData>().ToString();

                var result = await new HttpFactory(_analysisSettings).CallService(ApiActionType.TextAnalyticsSentiment,payload);

                if (result.Successfull)
                {
                    var txtAnalyticResult = new TextAnalyticSentimentResult(result.Data);
                    var resultSet = new TextAnalyticAnalysisSentimentResultSet(apiAction, txtAnalyticResult);
                    return ApiAnalysisResults.Create(resultSet);
                }
            }

            var phrases = _analysisSettings.ActionsToPerform.Where(a => a.ActionType == Configuration.ApiActionType.TextAnalyticsKeyphrases).ToList();
            if (phrases.Count > 0)
            {
                var apiAction = phrases.First() as TextAnalyticApiAction;
                var payload = apiAction.ActionData<TextAnalyticActionData>().ToString();

                var result = await new HttpFactory(_analysisSettings).CallService(ApiActionType.TextAnalyticsKeyphrases,payload);

                if (result.Successfull)
                {
                    var txtAnalyticResult = new TextAnalyticKeyPhraseResult(result.Data);
                    var resultSet = new TextAnalyticAnalysisKeyPhraseResultSet(apiAction, txtAnalyticResult);
                    return ApiAnalysisResults.Create(resultSet);
                }
            }

            return apiResults;

        }
    }
}
