= [Home](/README.md)/Common

### This section is incomplete - WIP

# ComputerVision Cognitive Service
The ComputerVision cognitive service provides the ability to analysis an image or video to provide descriptive details such 
as descritpive tags, is there racy or adult content present, are there any celebrities identified as well as face recognition.

Currently, only image analysis option is supported with more to come.

## ComputerVision Usage
To analyse a static image, you can do the following:
```c#
var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("YOUR-API-KEY", LocationKeyIdentifier.SouthEastAsia)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithComputerVisionAnalysisActions()
    .AddImageAnalysis("http://www.scface.org/examples/001_frontal.jpg",ImageAnalysisVisualFeatures.Faces)
    .AnalyseAllAsync();
```
