= [Home](/README.md)/Common

### This section is incomplete - WIP

# ComputerVision Cognitive Service
The ComputerVision cognitive service provides the ability to analysis an image or video to provide descriptive details such 
as descritpive tags, is there racy or adult content present, are there any celebrities identified as well as facial recognition.

Currently, only image analysis option is supported with more to come.

## ComputerVision Usage
To analyse a static image that is specified via a Url, you can do the following:
```c#
var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("YOUR-API-KEY", LocationKeyIdentifier.SouthEastAsia)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithComputerVisionAnalysisActions()
    .AddUrlForImageAnalysis("http://www.scface.org/examples/001_frontal.jpg",ImageAnalysisVisualFeatures.Faces)
    .AnalyseAllAsync();
```

To analyse a static image that is specified via a filename, you can do the following:
```c#
var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("YOUR-API-KEY", LocationKeyIdentifier.SouthEastAsia)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithComputerVisionAnalysisActions()
    .AddFileForImageAnalysis("c:\\SomeDirectory\\my-image.jpg",ImageAnalysisVisualFeatures.Faces)
    .AnalyseAllAsync();
```

Alternatively, you can specify the raw binary data for the image in the form of a byte array using the following:
```c#
var fileData = File.ReadAllBytes("c:\\SomeDirectory\\my-image.jpg");
var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("YOUR-API-KEY", LocationKeyIdentifier.SouthEastAsia)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithComputerVisionAnalysisActions()
    .AddFileForImageAnalysis(fileData,ImageAnalysisVisualFeatures.Faces)
    .AnalyseAllAsync();
```

You can also specify multiple images to process. Each image specified results in a separate call to the API. Unlike TextAnalytics which supports 
batching each input into a single call, ComputerVision requires a separate API call per image. The results are then returned in a single
collection. You can specify multiple images easily as shown in the following example:

```c#
var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("YOUR-API-KEY", LocationKeyIdentifier.SouthEastAsia)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithComputerVisionAnalysisActions()
    .AddUrlForImageAnalysis("http://www.scface.org/examples/001_frontal.jpg",ImageAnalysisVisualFeatures.Faces)
    .AddUrlForImageAnalysis("http://recognitionmemory.org/files/2016/04/C2_032.jpg",ImageAnalysisVisualFeatures.Categories)
    .AnalyseAllAsync();
```

You can also mix and match the types of images being processed. That is, you can specify a Url and an actual binary file as
part of the pipeline and they all get processed via separate API calls as expected, with the results populated as you would expect.

```c#
var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.ComputerVisionApiKey, LocationKeyIdentifier.SouthEastAsia)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithComputerVisionAnalysisActions()
    .AddFileForImageAnalysis("c:\\SomeDirectory\\my-image.jpg", ImageAnalysisVisualFeatures.Tags)
    .AddUrlForImageAnalysis("http://www.scface.org/examples/001_frontal.jpg",ImageAnalysisVisualFeatures.Faces)
    .AnalyseAllAsync();

// Our first image analysis only requested tags so we check we have some
Assert.NotEmpty(result.ImageAnalysis.AnalysisResults[0].ResponseData.tags);
// Our second image anlysis only requested faces so we check we have some
Assert.NotEmpty(result.ImageAnalysis.AnalysisResults[1].ResponseData.faces);
```