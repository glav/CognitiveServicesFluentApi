= [Home](/README.md)/LUIS

### This section is incomplete - WIP

# LUIS API Service
The LUIS cognitive service provides a language understanding ability on free form text. This Fluent API is not meant to replace the more complex LUIS library that supports stateful conversations, but rather a simplified approach to get results from basic LUIS interactions in an easy way.

## LUIS Usage
To extract intents and entities from textual conversation you can do the following:
```c#
var result = await CreateUsingConfigurationKeys("LUIS-APP-KEY","SUBSCRIPTOIN-KEY", LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithLuisAnalysisActions()
    .AddLuisAnalysis("Where can I find example ARM Templates")
    .AnalyseAllAsync();
```

### Examining results
In order to examine the results, an aggregate object is provided with the predictions around intents and entities detected. Continuing on from the example above:

```c#
var topIntent = result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.topIntent;  // Retrieve the top detected intent.

var singleIntent = result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.intents[0].intent;
var confidenceScore = result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.intents[0].score;

var singleEntity = result.LuisAppAnalysis.AnalysisResult.ResponseData.prediction.entityInstanceList.entityIdentifiers[0].entities[0];
```

When using the extensions package, this can be simplified into:
```c#
var topIntents = result.LuisAppAnalysis.GetTopIntents(); // We can get multiple top intents if we submit multiple queries.
var topIntent = topIntents.First();
```
