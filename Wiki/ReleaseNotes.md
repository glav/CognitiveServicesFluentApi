
## Version: 0.9.0 [01/22/2019 09:38:47]
### New Items
* a5512c0 -Completely removing Emotion from Wiki, remaining enumerations and tests
* e79dd0c -Removal of deprecated Emotion API and associated tests
* ac88577 -Added end to end support for Face Detection API and a test - WIP
* 634a990 -Added FaceDetection response structures and property elements
* 6b7c56a -Added Empty Wiki elements for Face API support and custom score levels
* 89053fc -Adding initial structure of Face API support
### Bugfixes
* aa7d7ad -Added test for age and gender, fixed bug in age parsing
### Full change list
* d258a7a Ensuring TextAnalytic has consistent version after Face API addition
* 375f902 Minor typo in Wiki
* a5512c0 NEW:Completely removing Emotion from Wiki, remaining enumerations and tests
* e79dd0c NEW:Removal of deprecated Emotion API and associated tests
* 0e62e44 Updated the Face Wiki
* 09d4ae5 Updated the Face Wiki
* cf3994a Added extra assertion for blur level
* 63c9208 Added support for extra face attributes
* 0bcf8c7 Added gender extension method and test
* ab1bbf4 Updated versioning script to use BUG not BUGFIX as tag text for bugs
* aa7d7ad BUG:Added test for age and gender, fixed bug in age parsing
* a16a351 Split out response classes for face detection into separate files, added some common extension methods
* 71aa8ae Bringing all versions to 0.9 to prep for Face API and subsequent 1.0 release
* 0cfcb2a Actually committed the test this time
* 83a79e2 Fixed bug with FaceAPI and made tests work
* 81ec78b Added FaceApiKey config to integration tests
* ac88577 NEW:Added end to end support for Face Detection API and a test - WIP
* e8122a6 Added another test around enum parsing
* 038db73 Added conversion functionality for enum values in FACE
* 277c9c8 Added face enum parsing and tests
* 685d0fc Added basic parsing test for FaceDetection - need to flesh out more
* 634a990 NEW:Added FaceDetection response structures and property elements
* d0d71d8 NSW:Adding Configuration classes to support Face API
* 6b7c56a NEW:Added Empty Wiki elements for Face API support and custom score levels
* 89053fc NEW:Adding initial structure of Face API support

## Version: 0.8.9.1 [01/08/2019 12:22:03]
### New Items
* ac1c9f6 -Validating name value for Score definitions to be non empty
* 33d0594 -Added GetInitialErrorMessage to all other context results
* 788b56e -Added GetInitialErrorMessage extension method for easir parsing when errors occur and bumped version
### Full change list
* 54be62f Changing version to path bump only
* fcbced6 Aded tests for custom score levels
* d7be714 BUG:Added language test for confidence level result extension and fixed normalisation bug
* 2003916 Added a LanguageAnalysis test to ensure end to end parsing
* 0b59e1f Removed unused response root for old Topic analysis fuctionality
* 59888dc Adding an extra test around LanguageContext extensions and parsing
* 3f83409 Adding some basic tests around Uri config
* adf6017 Updating to latest .Net Test SDK
* ac1c9f6 NEW:Validating name value for Score definitions to be non empty
* fc9f403 Removing unused parameter from HTTP call
* 5775448 Fixing code smell
* 33d0594 NEW:Added GetInitialErrorMessage to all other context results
* 75d0c60 Version bump of computer vision
* 178b5e3 Cleanup of unused usings
* 788b56e NEW:Added GetInitialErrorMessage extension method for easir parsing when errors occur and bumped version
* 065110b More cleanup via code recommendations
* 2810ba9 Code cleanup via recommendatins from SonarQube

## Version: 0.8.9 [01/04/2019 15:38:48]
### New Items
* d2be580 -Added support for Nuget LicenceExpression for each package
### Full change list
* d2be580 NEW:Added support for Nuget LicenceExpression for each package

## Version: 0.8.8 [01/04/2019 15:18:27]
### New Items
* 8130eac -Added GetAllKeyPhrases extension method and test
### Full change list
* 021781b Updated the documentation with new extension methods
* 8130eac NEW:Added GetAllKeyPhrases extension method and test
* 8a472a4 Upped version, added GetResults extension to KeyPhrase and added some tests

## Version: 0.8.8 [01/04/2019 13:58:30]
### New Items
* 8130eac -Added GetAllKeyPhrases extension method and test
### Full change list
* 021781b Updated the documentation with new extension methods
* 8130eac NEW:Added GetAllKeyPhrases extension method and test
* 8a472a4 Upped version, added GetResults extension to KeyPhrase and added some tests

## Version: 0.8.7 [12/14/2018 13:25:06]
### New Items
* 7c7850f -Add SplitIntoSentences analysis to keyphrase fluent API
### Full change list
* 7c7850f NEW:Add SplitIntoSentences analysis to keyphrase fluent API

## Version: Release_0.8.6 [12/14/2018 07:19:20]
### New Items
* d8edefe -Added support for splitting text into sentences for sentiment analysis
### Full change list
* 743c236 Added better failed call detection where a call can partially succeed
* d8edefe NEW:Added support for splitting text into sentences for sentiment analysis
* 417901a Merge branch 'master' of https://github.com/glav/CognitiveServicesFluentApi
* a0eb898 Updated release notes for Release_0.8.5
* 90bdf66 BUG: Updated TextAnalytics error parsing

## Version: 0.8.5 [12/05/2018 08:31:47]
### Full change list
* 90bdf66 BUG: Updated TextAnalytics error parsing
* 010aa50 Removed global.json
* 45404a4 Modified global.json for latest runtime after machine rebuid and latest .Net core runtime
* 8b6170d More very minor documentation update
* e6a8ff5 Minor docuemtnation update

## Version: 0.8.4 [08/01/2018 17:45:39]
### New Items
* 67e7aab -Added support got RecognizeText operation in ComputerVision
### Full change list
* b18438c Aligning version numbers during this pre-release phase to all match
* b3b4ae9 Updated Wiki documentation and added some more flexibility in RecognizeText extension API
* aee2477 Simple cleanup
* 59b54db Slight modification of extension method logic
* a0df844 Added  unit test for parsing results
* 0503e68 Added more assertions to test and added extra extension for RecogniseTextResult
* d088a0f Actually got the first full integration test working with RecognizeText
* d87fd32 Fixed bug in UrlQueryArguments for RecognizeText submission and also added test for OperationStatus component
* 6782075 Fixing minor parsing logic in TextAnalytics
* 90ebf69 Finalising input pipeline and a basic test
* 59ce6ea Added scaffolding for RecognizeTex ComputerVision API result parsing
* 766dab7 Support ability to add input action data for RecognizeText API
* 6839043 BUG:Added missing example documetation to Wiki for Ocr anaysis actions
* e6581c4 Bumped up minor version for ComputerVision and Core
* 67e7aab NEW:Added support got RecognizeText operation in ComputerVision

## Version: 0.8.3 [06/28/2018 17:32:20]
### Full change list
* be1c12d Merge branch 'glav/OCRSupport' of https://github.com/glav/CognitiveServicesFluentApi into glav/OCRSupport
* cde1450 Fixed stupid typo in release notes script
* febd95b Amended the release notes script to commit updated release notes and tag repo
* 9613753 Adding in custom build script to generate change list and tag repository
* 07475b2 Empty ItemGroup project file cleanup
* 8f6993d Added in full language list support for OCR
* 11e4576 Added language parsing for OCR results and added test
* a8c2e9f Moved out language classes for cleaner code
* aaab0df Added extension method for strongly typed OcrTextOrientation and added test
* e5f22e2 Added interface and extension method to extract boundingBox co-ordinates from an item as integers
* e30e12f Added more tests and changed name of OCR extension methods to not conflict
* 8ca0ac4 Added some integration tests for OCR
* 84cc8f3 Finished asserting values for parsing test
* 3b7bf1b Updating tests
* ae819bb Added BoundingBoxCoordinates type and tests
* e3d0c3c Adding core configuration elements for OCR support
* c820274 Ading OCR support o computer vision. WIP
* f8fdf5a Empty ItemGroup project file cleanup
* efae4eb Merge branch 'master' into glav/OCRSupport
* 91ae89b Added support for full debugging info for code coverage support and enabled .Net Core 2.1.3 support
* 16c9be6 Merge branch 'master' into glav/OCRSupport
* c820543 Added in full language list support for OCR
* e91701c Added language parsing for OCR results and added test
* de9d4f2 Moved out language classes for cleaner code
* bb330c2 Added extension method for strongly typed OcrTextOrientation and added test
* 4cc4cb9 Added interface and extension method to extract boundingBox co-ordinates from an item as integers
* 29f2b1e Added more tests and changed name of OCR extension methods to not conflict
* 6e24414 Added some integration tests for OCR
* 50bca55 Finished asserting values for parsing test
* 576a0a7 Updating tests
* bab26fe Added BoundingBoxCoordinates type and tests
* 230ab2e Adding core configuration elements for OCR support
* bbaa786 Ading OCR support o computer vision. WIP

## Version: 0.8.2 [06/27/2018 16:41:07]
### Full change list
* 2462f41 Probably line friggen endings
* 4e0d3df Minor change to ComputerVision documentation
* 36d55b6 Updated wiki documentation for ImageAnlysis to show url and binary file usage in same pipeline
* db8bfba Updated ComputerVision tests to ensure can pass in Url and File and they both get processed as expected
* 91bd6db Refactored the image analysis extension method names and modified the ComputerVision documentation to suit
* bd8ca7b Added more menaingul asserts to test
* 9a0f3ab Minor refactoring and getting test working with embedded image data
* 39bfb7b No real change, just line endings
* 39b5968 Got image binary POST working with a test but test needs work
* 0f86657 Hookup the isBinaryData
* 632479f Make it compile and tests pass
* f25d48b Sonarcube fixes
* 36bbc4f Added 'tags' extension methods and tests for computer vision
* 6f3e626 Updating doumentation/wiki
* 3eff5a8 Upping minor version number
* fa5f482 Fixing emotion tests
* a50ddac Fixed after rebase/pull
* c34ac3b Ensured test for deprecated emotion API validates multi request support
* 207be15 Updated tests for Computer vision and also updated deprecated Emotion API to support multi response
* d0c6343 Beginning of multiple result support for non batched
* 06d9509 fix typo
* c6580c2 Actually compiles :-) Need to support multiple return results for non batched operations
* 7f55aa3 Preparing for multiple results for multiple API calls per action
* 19041e4 Well it compiles :-) Modified emotion to support multiple action data items as well
* a91d040 Modified ComputerVision to support multiple items and amended tests
* 3449e95 Beginning of multiple result support for non batched
* 71be6b4 fix typo
* e2a69cb Actually compiles :-) Need to support multiple return results for non batched operations
* b8a5bb5 Preparing for multiple results for multiple API calls per action
* eb16f71 Fix one more issue
* 65ca6bb One minor fix as per sonarqube
* e87880b Merge branch 'master' into glav/MultipleActionDataItemSupport
* 489871f Merge branch 'master' of github.com:glav/CognitiveServicesFluentApi
* df0b13d Fixed up some sonarqube rported issues
* 30c932a Doh, made it an image incorrectly
* cda9431 Added link to sonarqube Code analysis report
* dec9df5 Well it compiles :-) Modified emotion to support multiple action data items as well
* 945dc4f Modified ComputerVision to support multiple items and amended tests
* 4204013 Added a test to verify multiple actions for Text analytics and some methods documentation
* b15f27e Fix serialisaiton of multiple documents of same type in TextAnalytics to support multiple actions
* 8e79696 Regenerated key2 and removed the old one from config coz I (again) committed the stupid thing
* ac472c0 refactor to cater for global location identifier
* 17b7ab3 Minor fix to readme
