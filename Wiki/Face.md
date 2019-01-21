= [Home](/README.md)/Face

### This section is incomplete - WIP

# Face API Service
The Face cognitive service provides the ability to perform face detection, verify face matches, and generally manage a wide area of facial recognition features through the analysis of images and/or video.

## Face Usage
To analyse the emotions of a static image, you can do the following:
```c#
var result = await EmotionConfigurationSettings.CreateUsingConfigurationKeys("YOUR-API-KEY", LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithFaceAnalysisActions()
    .AddUrlForFaceDetection("http://www.scface.org/examples/001_frontal.jpg",FaceDetectionAttributes.Gender | FaceDetectionAttributes.Age)
    .AnalyseAllAsync();
```
