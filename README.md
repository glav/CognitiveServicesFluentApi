# CognitiveServicesFluentApi
A fluent API to use with the Microsoft Cortana suite of cognitive services. Currently this API only supports TextAnalytics and Emotion services but more will come. Computer Vision is currently a work in progress.

The objective is to make the set of Cognitive service API's really easy to consume from .Net applications. In addition, a set of helper extension methods are available to try and make common functionality super easy to access.

## How to get started.
Easiest way is to install the nuget package for your specific analysis functionality. Note: packages are currentlt pre-release so you need the version specifier.
#### For text analyitics (such as Sentiment analysis):

```powershell
Install-Package Glav.CognitiveServices.FluentApi.TextAnalytic -Version 0.5.0-alpha
```

#### For Emotion (such as face and emotion detection in images)
```powershell
Install-Package Glav.CognitiveServices.FluentApi.Emotion -Version 0.5.0-alpha
```

#### Start coding
In order to make use of Cognitive services, you need to have an instance of the cognitive service setup in your Azure subscription. ![This link](https://docs.microsoft.com/en-us/azure/cognitive-services/cognitive-services-apis-create-account) shows you how to do this. You will then have two crucial pieces of information:
1. An API Key
2. A Location where your service is hosted.

You will need these to supply to the fluent API to allow it to call the correct service.

Create a new console project (or any type, but console is easiest to start).
Depending on what cognitive service you are using, add the following using statement:
``` c#
// For TextAnalytics API
using Glav.CognitiveServices.FluentApi.TextAnalytic;

// For Emotion API
using Glav.CognitiveServices.FluentApi.Emotion;
```


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

## Emotion Usage
To analyse the emotions of a static image, you can do the following:
```c#
var result = await EmotionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.EmotionApiKey, LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithEmotionAnalysisActions()
    .AddImageRecognition("http://www.scface.org/examples/001_frontal.jpg")
    .AnalyseAllEmotionsAsync();
```

### Note
This API is only in early stages and many refinements are yet to be applied.

#### Build Status
![Build Status](https://glav.visualstudio.com/_apis/public/build/definitions/ce515890-8bbd-414a-8432-78aacd311745/34/badge)


