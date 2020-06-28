# CognitiveServicesFluentApi
A fluent API to use with the Microsoft Cortana suite of cognitive services. Currently this API supports TextAnalytics, ComputerVision and Face cognitive services. 

The objective is to make the set of Cognitive service API's really easy to consume from .Net applications. In addition, a set of helper extension methods are available to try and make common functionality super easy to access.

If you are new to this project, please see the getting started section below. For those wanting detailed documentation, here you go:
* [Common/Core Fluent API](./Wiki/Common.md)
* [TextAnalytics Fluent API](./Wiki/TextAnalytics.md)
* [ComputerVision Fluent API](./Wiki/ComputerVision.md)
* [Face Fluent API](./Wiki/Face.md)
* [Scoring system](./Wiki/Scoring.md)

#### Build Status
[![Build Status](https://dev.azure.com/glav/Glav.CognitiveServices.Api/_apis/build/status/CognitiveServicesFluentApi%20CI%20Yaml?branchName=master)](https://dev.azure.com/glav/Glav.CognitiveServices.Api/_build/latest?definitionId=63&branchName=master)

#### Sonarqube Code Analaysis
[Sonarqube Code Analysis report](https://sonarcloud.io/dashboard?id=CognitiveFluentApi)

#### Project Board
[Azure DevOps project Board is located here](https://dev.azure.com/glav/Glav.CognitiveServices.Api)

## How to get started.
Easiest way is to install the nuget package for your specific analysis functionality. 
Note that the fluent API for each cognitive service has a set of convenience or extension methods which is located in a separate package for ease of updates. 
It is recommended (at least initially) to install the 'Extensions' package as that includes the dependent fluent API package and provides extra convenience. More
details on those extension/convenience methods is provided within the specific fluent API documentation.

#### For text analyitics (such as Sentiment analysis):

```powershell
Install-Package Glav.CognitiveServices.FluentApi.TextAnalytic.Extensions # Fluent API with included extension/convenience methods
# -or-
Install-Package Glav.CognitiveServices.FluentApi.TextAnalytic  # Just the Fluent API
```
or using dotnet CLI
```
dotnet add package Glav.CognitiveServices.FluentApi.TextAnalytic.Extensions
```

#### For ComputerVision (such as image description or adult content detection in images)
```powershell
Install-Package Glav.CognitiveServices.FluentApi.ComputerVision.Extensions # Fluent API with included extension/convenience methods
# -or-
Install-Package Glav.CognitiveServices.FluentApi.ComputerVision # Just the Fluent API
```
via dotnet CLI
or using dotnet CLI
```
dotnet add package Glav.CognitiveServices.FluentApi.ComputerVision.Extensions
```

#### For Face
```powershell
Install-Package Glav.CognitiveServices.FluentApi.Face.Extensions # Fluent API with included extension/convenience methods
# -or-
Install-Package Glav.CognitiveServices.FluentApi.Face # Just the Fluent API
```
via dotnet CLI
or using dotnet CLI
```
dotnet add package Glav.CognitiveServices.FluentApi.Face.Extensions
```


#### Azure Cognitive Services Setup
In order to make use of Cognitive services, you need to have an instance of the cognitive service setup in your Azure subscription. [This link](https://docs.microsoft.com/en-us/azure/cognitive-services/cognitive-services-apis-create-account) shows you how to do this. You will then have two crucial pieces of information:
1. An API Key
2. A Location where your service is hosted.

You will need these to supply to the fluent API to allow it to call the correct service.

#### Start coding

Create a new console project (or any type, but console is easiest to start).
Depending on what cognitive service you are using, add the following using statement:
``` c#
// For TextAnalytics API
using Glav.CognitiveServices.FluentApi.TextAnalytic;

// For Face API
using Glav.CognitiveServices.FluentApi.Face;

// For ComputerVision API
using Glav.CognitiveServices.FluentApi.ComputerVision;

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
Where:
* '**YOUR-API-KEY**': String API key obtained from the Azure portal for your instance of the cognitive service to be used.
* '**LocationKeyIdentifier**': The enumeration of type `Glav.CognitiveServices.FluentApi.Core.LocationKeyIdentifier` which specifies the location in which your cognitive service was provisioned. This is important as it dictates how the Url is formed when communicating with the service.

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
.AddLanguageAnalysis("I think I am in english")
```
Once our actions are added, we can invoke the processing of that data. For TextAnalytics, this is using:
``` c#
.AnalyseAllAsync();
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
    .AddLanguageAnalysis("I think I am in english")
    .AnalyseAllAsync();
```

#### Examining the results
Each cognitive service API (such as TextAnalytics or Face) provides a different type of results since they are performing different actions. However there are some similarities or patterns. Each result will contain a property that houses all the input data and result data for any operations performed. Continuing with the TextAnalytic theme using the above example, the resultof the analyse call contains properties to hold the Sentiment analysis, keyphrase analysis, and language analysis.
``` c#
result.SentimentAnalysis;
result.KeyPhraseAnalysis;
result.LanguageAnalysis;
``` 
Each property has a GetResults() method to conveniently return the ist of results. Alternatively, you can drill down into properties of the analysis object but it can be quite verbose.
``` c#
result.SentimentAnalysis.GetResults();
result.KeyPhraseAnalysis.GetResults();
result.LanguageAnalysis.GetResults();
``` 
It is best to look at the specific documentation for each set of operations to further determine what actions can be performed against the result set. Often, specific methods are avlailable to extract or examine the results.

#### The scoring system
Common to almost all cognitive service operations is a confidence score for the returned result. This value is always in between 0 and 1 inclusive. 0 represents a negative, or low confidence score whereas 1 represents a positive, or high confidence score. A score of 0.5 is considered neutral. The values of the scores and the variation in the scores will mean different things to different actions. This fluent API provides a default set of score levels for each API set, that is, one for TextAnalytics, one for Face etc. These are the defaults but can be completely customised to suit.

The default score levels are the following:
* 0 - 0.35 : "Negative"
* 0.35 - 0.45 : "Slightly Negative"
* 0.45 - 0.55 : "Neutral"
* 0.55 - 0.75 : "Slightly Positive"
* 0.75 - 1 : "Positive"

In the default scoring engine, the "upper bound" is not inclusive (using the default/supplied scoring engine). For example, a value must be greater than or equal to 0 and less than 0.35 to be considered "Negative". All upper bounds are non inclusive, with the exception of 1.

TextAnalystics uses these scores by default. Face has a slightly different default set of scores.
* 0 - 0.15 : "Definitely Negative"
* 0.15 - 0.35 : "Probably Negative"
* 0.35 - 0.49 : "Possibly Negative"
* 0.49 - 0.51 : "Neutral"
* 0.51 - 0.65 : "Possibly Positive"
* 0.65 - 0.85 : "Probably Positive"
* 0.85 - 1 : "Definitely Positive"

This is all well and good, but how do we use this?

Each result set or context has a scoring engine with scoring levels attached to it. This can be used as shown in the following Sentiment analysis example:
``` c#
var items = result.SentimentAnalysis.GetResults();
var firstItem = items.First();
var score = result.SentimentAnalysis.Score(firstItem);
Console.WriteLine($"Score level is: {score.Name}");
```
Alternatively, you can also provide the confidence level directly:
``` c#
var score = result.SentimentAnalysis.Score(0.987);
``` 
Each API operates a little different in terms of scoring and the fluent API differs a little for the specific API to accomodate this. For example, for Sentiment analysis, you can find all the results with a negative sentiment with the following:
``` c#
var negativeResults = result.SentimentAnalysis.GetResults(DefaultScoreLevels.Negative);
```

This is just the beginning though. For full details on all the fluent API options available for each API set, please use the links for the detailed documentation around each fluent API. Similarly, for further details on usage and customisation of the scoring levels, please see the links on that section.

### Change/Modification Log
* [Detailed change log](./Wiki/ReleaseNotes.md)

### Note
This API is only in early stages and many refinements are yet to be applied.

