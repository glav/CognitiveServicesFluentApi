using Glav.CognitiveServices.FluentApi.Core.Configuration;
using System;
using System.Threading.Tasks;
using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using Glav.CognitiveServices.FluentApi.Core.Contracts;

namespace Glav.CognitiveServices.FluentApi.TextAnalytic
{
    public sealed class TextAnalyticAnalysisEngine : BaseAnalysisEngine<TextAnalyticAnalysisResults, TextAnalyticActionData>
    {
        public TextAnalyticAnalysisEngine(CoreAnalysisSettings analysisSettings) : base(analysisSettings)
        {
        }


        public override async Task<TextAnalyticAnalysisResults> AnalyseAllAsync()
        {
            var apiResults = new TextAnalyticAnalysisResults(AnalysisSettings);
            await AnalyseApiActionAsync(apiResults, ApiActionType.TextAnalyticsSentiment);
            await AnalyseApiActionAsync(apiResults, ApiActionType.TextAnalyticsKeyphrases);
            await AnalyseApiActionAsync(apiResults, ApiActionType.TextAnalyticsLanguages);

            return apiResults;
        }

        public override async Task AnalyseApiActionAsync(TextAnalyticAnalysisResults apiResults, ApiActionType apiAction)
        {
            await base.AnalyseApiActionAsync(apiResults, apiAction, (actionData, commsResult) =>
              {
                  var textAnalyticActionData = actionData as TextAnalyticActionData;
                  switch (apiAction)
                  {
                      case ApiActionType.TextAnalyticsSentiment:
                          apiResults.SetResult(new SentimentAnalysisContext(textAnalyticActionData, new SentimentResult(commsResult)));
                          break;
                      case ApiActionType.TextAnalyticsKeyphrases:
                          apiResults.SetResult(new KeyPhraseAnalysisContext(textAnalyticActionData, new KeyPhraseResult(commsResult)));
                          break;
                      case ApiActionType.TextAnalyticsLanguages:
                          apiResults.SetResult(new LanguageAnalysisContext(textAnalyticActionData, new LanguagesResult(commsResult)));
                          break;
                      default:
                          throw new NotSupportedException($"{apiAction.ToString()} not supported yet");
                  }

              });
        }
    }
}
