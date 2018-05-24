using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public sealed class TextAnalyticAnalysisEngine : BaseAnalysisEngine<TextAnalyticAnalysisResults>
    {
        public TextAnalyticAnalysisEngine(CoreAnalysisSettings analysisSettings) : base(analysisSettings)
        {
        }


        public override async Task<TextAnalyticAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new TextAnalyticAnalysisResults(AnalysisSettings);
            await AnalyseApiActionAsync(apiResults, ApiActionType.TextAnalyticsSentiment).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, ApiActionType.TextAnalyticsKeyphrases).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, ApiActionType.TextAnalyticsLanguages).ConfigureAwait(continueOnCapturedContext: false);

            return apiResults;
        }


        public override async Task AnalyseApiActionAsync(TextAnalyticAnalysisResults apiResults, ApiActionType apiAction)
        {
            await base.AnalyseApiActionAsync(apiResults, apiAction, (actionData, commsResult) =>
            {
                switch (apiAction)
                {
                    case ApiActionType.TextAnalyticsSentiment:
                        apiResults.SetResult(new SentimentAnalysisContext(actionData, new SentimentResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                        break;
                    case ApiActionType.TextAnalyticsKeyphrases:
                        apiResults.SetResult(new KeyPhraseAnalysisContext(actionData, new KeyPhraseResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                        break;
                    case ApiActionType.TextAnalyticsLanguages:
                        apiResults.SetResult(new LanguageAnalysisContext(actionData, new LanguagesResult(commsResult), apiResults.AnalysisSettings.ConfigurationSettings.GlobalScoringEngine));
                        break;
                    default:
                        throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                }

            }).ConfigureAwait(continueOnCapturedContext: false);

        }
    }
}
