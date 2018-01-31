## Cognitive Services Fluent API Common/Core Functionality
Before we begin adding actions and data to operate with, there are many common or core fluent API methods for configuring cross cutting operations such as logging and communication menthods.

### ConfigurationSettings
Before we do anything, an initial configuration settings object must be created wiwth the API key and location specified.

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
* 'LocationKeyIdentifier': The enumeration of type 'Glav.CognitiveServices.FluentApi.Core.LocationKeyIdentifier' which specifies the location in which your cognitive service was provisioned. This is important as it dictates how the Url is formed when communicating with the service.

The 'CreateUsingConfigurationKeys' method returns an object of type 'ConfigurationSettings'. From this, we can then begin defining the common pipeline.

### Common pipeline operations
The following extensions methods or fluent API operations are available from the 'ConfigurationSettings' object.

#### .AddConsoleDiagnosticLogging()
* Returns: ConfigurationSettings
* Description: Adds diagnostic logging to the console.
* Example usage:
``` c#
TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.WestUs)
                .AddConsoleDiagnosticLogging()
```
#### .AddDebugDiagnosticLogging()
* Returns: ConfigurationSettings
* Description: Adds diagnostic logging using the System.Diagnostics.Debug writer.
* Example usage:
``` c#
TextAnalyticConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.WestUs)
                .AddDebugDiagnosticLogging()
```

#### .AddCustomDiagnosticLogging(IDiagnosticLogger)
* Returns: ConfigurationSettings
* Description: Adds diagnostic logging using a custom logging implementation that implements the 'IDiagnosticLogger' interface.
* Example usage:
``` c#
```
#### .SetDiagnosticLoggingLevel(LoggingLevel)
#### .UsingHttpCommunication()
Specifies a regular HTTP communications pipeline to communicate with the cognitive service.
> Example usage
``` c#
```