﻿using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Analysis;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.TextAnalytic.Domain;
using System;
using System.Threading.Tasks;

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
            await AnalyseApiActionAsync(apiResults, TextAnalyticApiOperations.SentimentAnalysis).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, TextAnalyticApiOperations.KeyPhraseAnalysis).ConfigureAwait(continueOnCapturedContext: false);
            await AnalyseApiActionAsync(apiResults, TextAnalyticApiOperations.LanguageAnalysis).ConfigureAwait(continueOnCapturedContext: false);

            return apiResults;
        }


        public override async Task AnalyseApiActionAsync(TextAnalyticAnalysisResults apiResults, ApiActionDefinition apiAction)
        {
            await base.AnalyseApiActionAsync(apiAction, (actionData, commsResult) =>
            {
                if (apiAction == TextAnalyticApiOperations.SentimentAnalysis)
                {
                    apiResults.SetResult(new SentimentAnalysisContext(actionData, new SentimentResult(commsResult)));
                    return;
                }
                if (apiAction == TextAnalyticApiOperations.KeyPhraseAnalysis)
                {
                    apiResults.SetResult(new KeyPhraseAnalysisContext(actionData, new KeyPhraseResult(commsResult)));
                    return;
                }
                if (apiAction == TextAnalyticApiOperations.LanguageAnalysis)
                {
                    apiResults.SetResult(new LanguageAnalysisContext(actionData, new LanguagesResult(commsResult)));
                    return;
                }
                throw new NotSupportedException($"{apiAction.ToString()} not supported yet");

            }).ConfigureAwait(continueOnCapturedContext: false);

        }
    }
}
