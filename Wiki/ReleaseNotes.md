
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
