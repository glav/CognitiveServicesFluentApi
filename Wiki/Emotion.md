= [Home](/readme.md)/Emotion

# Emotion Cognitive Service
The emotion cognitive service provides the ability to determine the emotional state of a person through the analysis of images and/or video.

Currently, only image recognition analysis option is supported with more to come.

## Emotion Usage
To analyse the emotions of a static image, you can do the following:
```c#
var result = await EmotionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.EmotionApiKey, LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithEmotionAnalysisActions()
    .AddImageRecognition("http://www.scface.org/examples/001_frontal.jpg")
    .AnalyseAllAsync();
```
