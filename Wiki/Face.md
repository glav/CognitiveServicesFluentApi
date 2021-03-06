= [Home](/README.md)/Face

### This section is incomplete - WIP

# Face API Service
The Face cognitive service provides the ability to perform face detection, verify face matches, and generally manage a wide area of facial recognition features through the analysis of images and/or video. In addition, the face cognitive service allows management of groups of people, with associated faces to train against for improved facial recognition processing.

## Face Usage
To detect a face in an image at a particular Url, then determine its gender and age, you can do the following:
```c#
var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("YOUR-API-KEY", LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithFaceAnalysisActions()
    .AddUrlForFaceDetection("http://www.scface.org/examples/001_frontal.jpg",FaceDetectionAttributes.Gender | FaceDetectionAttributes.Age)
    .AnalyseAllAsync();
```

Similarly, for an image that is specified via a filename, you can do the following:
```c#
var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("YOUR-API-KEY", LocationKeyIdentifier.WestUs)
    .SetDiagnosticLoggingLevel(LoggingLevel.Everything)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithFaceAnalysisActions()
    .AddFileForFaceDetection("c:\\SomeDirectory\\my-image.jpg",FaceDetectionAttributes.Gender | FaceDetectionAttributes.Age)
    .AnalyseAllAsync();
```

The Face API requires that you specify what attributes to identify in addition to face detection. Each additional attribute requires extra computation time (and thus cost). The is done by including specific FaceDetectionAttributes. In the previous examples, we asked to identify the gender and age of the face in the image. You can include one or all of the required attributes by performing a **logical OR** of the attributes required. The currently supported attributes are:
* None (default)
* Age
* Gender
* HeadPose
* Smile
* FacialHair
* Glasses
* Emotion
* Hair
* MakeUp
* Occlusion
* Accessories
* Blur
* Exposure
* Noise

### Examining results
In order to examine the results, an aggregate object is provided with the specific data structures populated depending on the attributes requested for face detection analysis. In addition to the data returned for each attribute, convenience extension methods are provided for Gender, Glasses, Exposure, Blur and Noise (assuming they are requested as part of the analysis). Some of these are shown in the example below.

*Note: The faceId property is important as it is used to reference further actions as part of the FaceAPI functionality.*

```c#
var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
    .AddDebugDiagnosticLogging()
    .UsingHttpCommunication()
    .WithFaceAnalysisActions()
    .AddUrlForFaceDetection("https://host/image.png",FaceDetectionAttributes.Gender | 
        FaceDetectionAttributes.Age | 
        FaceDetectionAttributes.Glasses |
        FaceDetectionAttributes.Exposure)
    .AnalyseAllAsync();

var resultContext = result.FaceDetectionAnalysis;
var results = resultContext.GetResults();
var firstResult = results.First();
var attributesReturned = firstResult.faceAttributes;

var isFemale = firstResult.IsGender(GenderType.Female));
var age = firstResult.faceAttributes.age;
var notWearingGlasses = firstResult.IsGlassesType(GlassesType.NoGlasses);
var imageHasGoodExposure = firstResult.IsExposureLevel(ExposureLevel.GoodExposure);
var faceId = firstResult.faceId;
```
## People/Person Group management
You can create, delete, and list groups which can contain a person or persons. In addition you can retrieve a single group and its related metadata.
```c#
var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
    .AddConsoleDiagnosticLogging()
    .UsingHttpCommunication()
    .WithFaceAnalysisActions()
    .CreateLargePersonGroup("123","unittest","unittest-data")
    .AnalyseAllAsync();
```

## People/Person Group management
You can create, delete, and list groups which can contain a person or persons. In addition you can retrieve a single group and its related metadata.
```c#
var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
    .AddConsoleDiagnosticLogging()
    .UsingHttpCommunication()
    .WithFaceAnalysisActions()
    .CreateLargePersonGroup("123","unittest","unittest-data")
    .AnalyseAllAsync();
```

## Person Face association and training
The supported person groups and face training are:
### LargePersonGroup
* CreateLargePersonGroup
* GetLargePersonGroup
* ListLargePersonGroups
* DeleteLargePersonGroup
* StartTrainingLargePersonGroup
* CheckTrainingStatusLargePersonGroup

### LargePersonGroupPerson
* CreateLargePersonGroupPerson
* GetLargePersonGroupPerson
* ListLargePersonGroupPersons
* DeleteLargePersonGroupPerson
* AddFaceToPersonGroupPerson
* GetFaceForPersonGroupPerson
* DeleteFaceForPersonGroupPerson

## People/Person Group management
You can create, delete, and list groups which can contain a person or persons. In addition you can retrieve a single group and its related metadata.
```c#
var result = await FaceConfigurationSettings.CreateUsingConfigurationKeys("123", LocationKeyIdentifier.AustraliaEast)
    .AddConsoleDiagnosticLogging()
    .UsingHttpCommunication()
    .WithFaceAnalysisActions()
    .CreateLargePersonGroup("123","unittest","unittest-data")
    .AnalyseAllAsync();
```

## Person Face association and training
The supported person groups and face training are:
### LargePersonGroup
* CreateLargePersonGroup
* GetLargePersonGroup
* ListLargePersonGroups
* DeleteLargePersonGroup
* StartTrainingLargePersonGroup
* CheckTrainingStatusLargePersonGroup

### LargePersonGroupPerson
* CreateLargePersonGroupPerson
* GetLargePersonGroupPerson
* ListLargePersonGroupPersons
* DeleteLargePersonGroupPerson
* AddFaceToPersonGroupPerson
* GetFaceForPersonGroupPerson
* DeleteFaceForPersonGroupPerson


## Extensions package
Glav.CognitiveServices.FluentApi.Face.Extensions
WIP
### Image Analysis
* IEnumerable<FaceDetectResponseItem> GetResults()
* bool IsGender(GenderType gender)
```c#
var results = result.FaceDetectionAnalysis.GetResults();
var isFemale = results.First().IsGender(GenderType.Female);
```
* bool IsGlassesType(GlassesType glasses)
```c#
var noGlasses = result.FaceDetectionAnalysis.First().IsGlassesType(GlassesType.NoGlasses);
```
* bool HasEyeMakeup()
```c#
var noGlasses = result.FaceDetectionAnalysis.First().HasEyeMakeup();
```
* bool HasLipMakeup()
```c#
var noGlasses = result.FaceDetectionAnalysis.First().HasLipMakeup();
```

* bool IsNoiseLevel(NoiseLevel level)
```c#
var noGlasses = result.FaceDetectionAnalysis.First().IsNoiseLevel(NoiseLevel.Low);
```
* bool IsExposureLevel(ExposureLevel level)
```c#
var noGlasses = result.FaceDetectionAnalysis.First().IsExposureLevel(ExposureLevel.GoodExposure);
```
* bool IsBlurLevel(BlurLevel level)
```c#
var noGlasses = result.FaceDetectionAnalysis.First().IsBlurLevel(BlurLevel.Low);
```

