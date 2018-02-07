= [Home](../readme.md)/Emotion

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
