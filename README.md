# CognitiveServicesFluentApi
A fluent API to use with Microsoft Cortana suite of cognitive services

## Usage
For example, to perform Sentiment Analysis on a piece of text, you can do:
```c#
var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey("my-api-key")
    .UsingHttpCommunication()
    .WithSentimentAnalysis("I am having a fantastic time.")
    .AnalyseAllSentimentsAsync();

var collectedResults = result.TextAnalyticSentimentAnalysis.GetResults(SentimentClassification.Positive);
Assert.NotNull(collectedResults);
Assert.Equal(1, collectedResults.Count());
```

And for Keyphrase analysis:
```c#
var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey("my-api-key")
    .UsingHttpCommunication()
    .WithKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
    .AnalyseAllSentimentsAsync();

var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey("my-api-key")
    .UsingHttpCommunication()
    .WithSentimentAnalysis("I am having a terrible time.")
    .WithKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
    .AnalyseAllSentimentsAsync();

Assert.Equal<string>("basic sentence", result.TextAnalyticKeyPhraseAnalysis.AnalysisResult.ResponseData.documents[0].keyPhrases[0]);
```

You can also chain operations:
```c#
var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey("my-api-key")
    .UsingHttpCommunication()
    .WithSentimentAnalysis("I am having a terrible time.")
    .WithKeyPhraseAnalysis("This is a basic sentence. I have absolutely nothing to assert here.")
    .AnalyseAllSentimentsAsync();

```

### Note
This API is only in early stages and many refinements are yet to be applied.

#### Build Status
![Build Status](https://glav.visualstudio.com/_apis/public/build/definitions/ce515890-8bbd-414a-8432-78aacd311745/34/badge)

So far, it only supports TextAnalytics, but more will come.

