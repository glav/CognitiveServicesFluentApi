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

Also add in these common using statements regardless of what service you are using:
``` c#
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core;
```
Now we can begin by creating a configuration setting for a particular cognitive service using the API key and location of our service we created in Azure. Let's start with TextAnalytics:
``` c#
var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey("YOUR-API-KEY", LocationKeyIdentifier.WestUs)
```
In the above statement, substitute your API key taken from the Azure portal, and also ensure the location is correct. Here we have assumed it is in West US.

We can now continue to configure how the core components should work with the cognitive service API. We can typically specify what logging to use and the type of communication. 

```c#
var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey("YOUR-API-KEY", LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()  // Using System.Diagnostics.Debug
    .UsingHttpCommunication()
```
Now we can start to define what actions to take. For TextAnalytics, this takes the form of the extension method:
``` c#
.WithTextAnalyticAnalysisActions()
```

Now we can add in our actions to perform with the associated data. To add in sentiment analysis for some text:
``` c#
.AddSentimentAnalysis("This is great.")
```
For Keyphrase analysis:
``` c#
.AddKeyPhraseAnalysis("This is a snippet of text")
```
For Language analysis:
``` c#
.AddKeyLanguageAnalysis("I think I am in english")
```
Once our actions are added, we can invoke the processing of that data. For TextAnalytics, this is using:
``` c#
.AnalyseAllSentimentsAsync();
```
Many actions can be added, and the respective cognitive services API's will be called and the results provided into an object that can be easily examined, and has it's own extension methods. However, to continue to use TextAnalytics as the example, putting it all together:
``` c#
var result = await TextAnalyticConfigurationSettings.CreateUsingApiKey("YOUR-API-KEY", LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()  // Using System.Diagnostics.Debug
    .UsingHttpCommunication()
    .WithTextAnalyticAnalysisActions()
    .AddSentimentAnalysis("This is great.")
    .AddKeyPhraseAnalysis("This is a snippet of text")
    .AddKeyLanguageAnalysis("I think I am in english")
    .AnalyseAllSentimentsAsync();
```

#### Examining the results
Each cognitive service API (such as TextAnalytics or Emotion) provides a different type of results since they are performing different actions. However there are some similarities or patterns. Each result will contain a property that houses all the input data and result data for any operations performed. Continuing with the TextAnalytic theme using the above example, the resultof the analyse call contains properties to hold the Sentiment analysis, keyprhase analysis, and language analysis.
``` c#
result.SentimentAnalysis();
result.KeyPhraseAnalysis();
result.LanguageAnalysis();
``` 
Each property has a GetResults() method to conveniently return the ist of results. Alternatively, you can drill down into properties of the analysis object but it can be quite verbose.
``` c#
result.SentimentAnalysis().GetResults();
result.KeyPhraseAnalysis().GetResults();
result.LanguageAnalysis().GetResults();
``` 
It is best to look at the specific documentation for each set of operations to further determine what actions can be performed against the result set. Often, specific methods are avlailable to extract or examine the results.

#### The scoring system
Common to almost all cognitive service operations is a confidence score for the returned result. This value is always in between 0 and 1 inclusive. 0 represents a negative, or low confidence score whereas 1 represents a positive, or high confidence score. A score of 0.5 is considered neutral. The values of the scores and the variation in the scores will mean different things to different actions. This fluent API provides a default set of score levels for each API set, that is, one for TextAnalytics, one for Emotion etc. These are the defaults but can be completely customised to suit.

The default score levels are the following:
* 0 - 0.35 : "Negative"
* 0.35 - 0.45 : "Slightly Negative"
* 0.45 - 0.55 : "Neutral"
* 0.55 - 0.75 : "Slightly Positive"
* 0.75 - 1 : "Positive"

In the default scoring engine, the "upper bound" is not inclusive. For example, a value must be greater than or equal to 0 and less than 0.35 to be considered "Negative". All upper bounds are non inclusive, with the exception of 1.

TextAnalystics uses these scores by default. Emotion has a slightly different default set of scores.
* 0 - 0.15 : "Definitely Negative"
* 0.15 - 0.35 : "Probably Negative"
* 0.35 - 0.49 : "Possibly Negative"
* 0.49 - 0.51 : "Neutral"
* 0.51 - 0.65 : "Possibly Positive"
* 0.65 - 0.85 : "Probably Positive"
* 0.85 - 1 : "Definitely Positive"


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


