= [Home](/README.md)/Common

### This section is incomplete - WIP

# ComputerVision Cognitive Service
The ComputerVision cognitive service provides the ability to analysis an image or video to provide descriptive details such 
as descritpive tags, is there racy or adult content present, are there any celebrities identified as well as facial recognition.

Currently, only image analysis and OCR API's are supported with more to come.

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
To perform OCR on a static image that is specified via a Url, you can do the following:
```c#
var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("YOUR-API-KEY", LocationKeyIdentifier.SouthEastAsia)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithComputerVisionAnalysisActions()
    .AddUrlForOcrAnalysis("http://www.scface.org/examples/001_frontal.jpg",false)
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

Similarly, to perform OCR on a static image that is specified via a filename, you can do the following:
```c#
var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys("YOUR-API-KEY", LocationKeyIdentifier.SouthEastAsia)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithComputerVisionAnalysisActions()
    .AddFileForOcrAnalysis("c:\\SomeDirectory\\my-image.jpg",false)
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

The Recognize text API is currently in preview at the time of this writing and provides recognition of handwritten or printed text. Thus API requires that a job
be submitted, and then queried to see when it has completed. To submit a job for processing, use the following:

```c#
var result = await ComputerVisionConfigurationSettings.CreateUsingConfigurationKeys(TestConfig.ComputerVisionApiKey, LocationKeyIdentifier.SouthEastAsia)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithComputerVisionAnalysisActions()
    .AddFileForRecognizeTextAnalysis("c:\\Images\\your_image.jpg",FluentApi.ComputerVision.Domain.RecognizeTextMode.Handwritten)
    .AnalyseAllAsync();
```

Like other APIs, this supports both a URL location for images, a physical location on disk, or an array of byte data representing the image.
Given the previous example, the status of the operation can be queried like:

```c#
var status = await result.CheckOperationStatusAsync();
var isFirstOpFinished = status.First().OperationState == FluentApi.Core.Operations.OperationStateType.CompletedSuccessfully;
```

This queries the operation status endpoint once for each RecognizeText action to retrieve the status of the operations. That status object will contain 
an OperationState property which can be one of the following values:
* NotStarted
* BadRequest
* Submitted
* Running
* CompletedSuccessfully
* Failed
* TimedOut
* Cancelled
* Uploaded

However, rather than calling that operation continually until the operation has completed, a convenience method is provided that waits for the operation
to complete. Given the example above, you do use the following:

```c#
var analysisResult = await result.WaitForOperationToCompleteAsync();
```
or for a little more control, you can specify a CancellationToken, total time to wait and time to wait between each query operation:
```c#
var token = new CancellationToken();
var analysisResult = await result.WaitForOperationToCompleteAsync(token, 30000, 2000);

var firstResult = analysisResult.First();
Assert.Equal("sometext", firstResult.GetAllRecognisedText().First());
```
where 30000 represents the total time in milliseconds to wait for this operation to complete (timeout) and 2000 represents the time in milliseconds to wait between each
status query operation.

## Extensions package
Glav.CognitiveServices.FluentApi.ComputerVision.Extensions
WIP
### Image Analysis
* bool IsAdultContent()
```c#
var result = analysisResult.ImageAnalysis.IsAdultContent();
```
* bool IsRacyContent()
```c#
var result = analysisResult.ImageAnalysis.IsRacyContent();
```
* string[] GetDescriptiveCaptions(double minimumConfidenceLevel)
```c#
var result = analysisResult.ImageAnalysis.GetDescriptiveCaptions(0.1);
```
* string[] GetDescriptiveCaptions(string scoreLevelDescription)
```c#
var result = analysisResult.ImageAnalysis.GetDescriptiveCaptions(DefaultScoreLevels.Positive);
```
* string[] GetTags(string scoreLevelDescription)
```c#
var result = analysisResult.ImageAnalysis.GetTags(DefaultScoreLevels.Positive);
```
* string[] GetTagsEqualToOrAboveAConfidenceLevel(string scoreLevelDescription)
```c#
var result = analysisResult.ImageAnalysis.GetTagsEqualToOrAboveAConfidenceLevel(DefaultScoreLevels.SlightlyPositive);
```

### Ocr Analysis
* IEnumerable<string> GetAllWords()
```c#
var words = result.OcrAnalysis.GetAllWords();
```
* SupportedLanguageItem LanguageDetected()
```c#
var lang = result.OcrAnalysis.LanguageDetected();
```

### Recognise Text Analysis
* IEnumerable<string> GetAllRecognisedText()
```c#
var analysisResult = await result.WaitForOperationToCompleteAsync();
var allText = analysisResult.First().GetAllRecognisedText();
```

