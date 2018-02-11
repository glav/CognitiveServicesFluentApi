= [Home](../readme.md)/TextAnalytics

# TextAnalytics Cognitive Service
The TextAnalytics cognitive service provides the ability to analyse text to determine what kind of sentiment is the text (such as positive or negative sentiment), what are the key phrases within that text, and what language is the text written in.

## TextAnalytics Usage
After defining the [common](../wiki/commom.md) options to use via the fluent API, to begin adding text analytics actions you must signify this intent by using the following method
```c#
.WithTextAnalyticAnalysisActions()
```
After which you can begin adding operations to perform.

### Sentiment analysis
```c#
.AddSentimentAnalysis("YOU TEXT TO ANALYSE")
```
### Keyphrase analysis
```c#
.AddKeyPhraseAnalysis("YOU TEXT TO ANALYSE")
```
### Language analysis
```c#
.AddLanguageAnalysis("YOU TEXT TO ANALYSE")
```


For example, to perform Sentiment Analysis on a piece of text, you can do:
```c#
var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey("my-api-key", LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithTextAnalyticAnalysisActions()
    .AddSentimentAnalysis("I am having a fantastic time.")
    .AnalyseAllAsync();

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
    .AnalyseAllAsync();

Assert.Equal<string>("basic sentence", result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.ResponseData.documents[0].keyPhrases[0]);
```

You can also chain operations. To perform both sentiment analysis and keyphrase analysis:
```c#
var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey("my-api-key", LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddConsoleDiagnosticLogging()  // just log to the console
    .UsingHttpCommunication()
    .WithTextAnalyticAnalysisActions()
    .AddSentimentAnalysis("I am having a terrible time.")
    .AddKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
    .AnalyseAllAsync();
```
This will call each api with the specified in an asynchronous manner and present the results once both operations are complete.
