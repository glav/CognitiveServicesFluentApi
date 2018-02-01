## Cognitive Services Fluent API Common/Core Functionality
Before we begin adding actions and data to operate with, there are many common or core fluent API methods for configuring cross cutting operations such as logging and communication menthods.

### ConfigurationSettings
Before we do anything, an initial configuration settings object must be created with the API key and location specified.

For TextAnalytics, this is done by:
``` c#
var config = TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("API-KEY", LocationKeyIdentifier)
```
For Emotion, this is done by:
``` c#
var config = EmotionConfigurationSettings.CreateUsingConfigurationKeys("API-KEY", LocationKeyIdentifier)
```

Where:
* 'API-KEY': String API key obtained from the Azure portal for your instance of the cognitive service to be used.
* 'LocationKeyIdentifier': The enumeration of type `Glav.CognitiveServices.FluentApi.Core.LocationKeyIdentifier` which specifies the location in which your cognitive service was provisioned. This is important as it dictates how the Url is formed when communicating with the service.

The `CreateUsingConfigurationKeys` method returns an object of type `ConfigurationSettings`. From this, we can then begin defining the common pipeline.

### Common pipeline operations
The following extensions methods or fluent API operations are available from the `ConfigurationSettings` object.

#### .AddConsoleDiagnosticLogging()
* Extends: `ConfigurationSettings`
* Returns: `ConfigurationSettings`
* Description: Adds diagnostic logging to the console.
> Example usage:
``` c#
TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.WestUs)
                .AddConsoleDiagnosticLogging()
```
#### .AddDebugDiagnosticLogging()
* Extends: `ConfigurationSettings`
* Returns: `ConfigurationSettings`
* Description: Adds diagnostic logging using the System.Diagnostics.Debug writer.
> Example usage:
``` c#
TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.WestUs)
                .AddDebugDiagnosticLogging()
```

#### .AddCustomDiagnosticLogging(IDiagnosticLogger)
* Extends: `ConfigurationSettings`
* Returns: `ConfigurationSettings`
* Description: Adds diagnostic logging using a custom logging implementation that implements the `IDiagnosticLogger` interface.

#### .SetDiagnosticLoggingLevel(LoggingLevel)
* Extends: `ConfigurationSettings`
* Returns: `ConfigurationSettings`
* Description: Sets the diagnostic logging level.
> Example usage:
``` c#
TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.WarningsAndErrors);
```

#### .UsingCustomGlobalScoringEngine(IScoreEvaluationEngine)
* Extends: `ConfigurationSettings`
* Returns: `ConfigurationSettings`
* Description: Specifies a custom global scoring engine that implements the `IScoreEvaluationEngine` interface. The global scoring engine is propagated to any fluent API engines that do not have specific implementations of their own such as TextAnalytics. This engine determines how an API result containing a confidence level result is calculated to have a particular meaning or score against a set of score level definitions.
> Example usage:
``` c#
public class MyScoringEngine : IScoreEvaluationEngine
{
    // .... interface methods
}

TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.WestUs)
    .UsingCustomGlobalScoringEngine(new MyScoringEngine(new DefaultScoreLevels()));
```


#### .UsingDefaultGlobalScoringEngineWithCustomScoreLevels(IScoreLevelBoundsCollection)
* Extends: `ConfigurationSettings`
* Returns: `ConfigurationSettings`
* Description: Specifies a custom set of score level definitions using an implementation of the `IScoreLevelBoundsCollection` interface (lower and upper bounds) to be used by the scoring engine when determining an API result confidence score. The global scoring engine and its associated scoring levels are propagated to any fluent API engines that do not have specific implementations of their own such as TextAnalytics. Note that the `BaseScoreLevelsCollection` class is an abstract class that implements `IScoreLevelBoundsCollection` but provides many convenience methods to allow easy score level definitions.
> Example usage:
``` c#
public class MyCustomScoreLevels : BaseScoreLevelsCollection
{
        public CustomScoreLevels()
        {
            ConstructDefaultValues();
        }

        private void ConstructDefaultValues()
        {
            AddStartingScoreLevel(0.3, "Very Low");
            AddNextScoreLevelDefinitionInList(0.4, "Somewhat low");
            AddNextScoreLevelDefinitionInList(0.6, "Middle");
            AddNextScoreLevelDefinitionInList(0.8, "High");
            AddFinalScoreLevel("Really Highs");
        }
}

TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.WestUs)
    .UsingDefaultGlobalScoringEngineWithCustomScoreLevels(new MyCustomScoreLevels());
```

#### .UsingHttpCommunication()
* Extends: `ConfigurationSettings`
* Returns: `CoreAnalysisSettings`
* Desription: Specifies a regular HTTP communications pipeline to communicate with the cognitive service. Since this returns an implemention of the CoreAnalysisSettings object and -not- `ConfigurationSettings` you can not specify any more `ConfigurationSettings` object extensions such as '.AddDebugDiagnosticLogging()'
> Example usage
``` c#
TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.WestUs)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication();
```

#### .UsingCustomCommunication(ICommunicationEngine)
* Extends: `ConfigurationSettings`
* Returns: `CoreAnalysisSettings`
* Desription: Specifies a custom communications pipeline that implements the `ICommunicationEngine` interface to communicate with the cognitive service. Since this returns an implemention of the CoreAnalysisSettings object and -not- `ConfigurationSettings` you can not specify any more `ConfigurationSettings` object extensions such as `.AddDebugDiagnosticLogging()`
> Example usage
``` c#
public class MockCommsEngine :  ICommunicationEngine
{
   // ... interface methods
}

TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.WestUs)
    .AddDebugDiagnosticLogging()
    .UsingCustomCommunication(new MockCommsEngine());
```