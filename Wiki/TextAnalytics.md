= [Home](../readme.md)/TextAnalytics

## TextAnalytics Usage
For example, to perform Sentiment Analysis on a piece of text, you can do:
```c#
var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey("my-api-key", LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithTextAnalyticAnalysisActions()
    .AddSentimentAnalysis("I am having a fantastic time.")
    .AnalyseAllSentimentsAsync();

var collectedResults = result.TextAnalyticSentimentAnalysis.GetResults(SentimentClassification.Positive);
Assert.NotNull(collectedResults);
Assert.Equal(1, collectedResults.Count());
```

And for Keyphrase analysis:
```c#
var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey("my-api-key", LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithTextAnalyticAnalysisActions()
    .AddKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
    .AnalyseAllSentimentsAsync();

Assert.Equal<string>("basic sentence", result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.ResponseData.documents[0].keyPhrases[0]);
```

You can also chain operations:
```c#
var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey("my-api-key", LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddConsoleDiagnosticLogging()  // just log to the console
    .UsingHttpCommunication()
    .WithTextAnalyticAnalysisActions()
    .AddSentimentAnalysis("I am having a terrible time.")
    .AddKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
    .AnalyseAllSentimentsAsync();
```
