
## Version: 1.2.0 [09/22/2020 09:24:42]
### New Items
* 3d8b500 -Adding consistent way to easily retrieve error messages from calls
### Full change list
* ce7bf92 Minor version bump
* 73d9f1e Refined GetAllErrors to return flat list for TextAnalytics for simplicity, modified some tests
* 7604315 Updated all other contexts to include GetAllErrors impl
* 3d8b500 NEW:Adding consistent way to easily retrieve error messages from calls
* aa10925 Merge pull request #28 from glav/glav/RemoveActionCI
* 5e15e5e Moved action CI into disabled so that only Azure DevOps pipelines is run otherwise tests run twice and often fail due to free tier quota
* fbcdf16 Merge branch 'trunk' of https://github.com/glav/CognitiveServicesFluentApi into trunk
* 104e55a Merge pull request #27 from glav/glav/StatusBade
* a11f7bd Merge branch 'trunk' of https://github.com/glav/CognitiveServicesFluentApi into trunk
* f8d58a5 Updated status badge
* 6e9154f Updated status badge
* 642959f Merge pull request #26 from glav/glav/master-to-trunk
* 515d993 Merge branch 'trunk' into glav/master-to-trunk
* bae1af1 Change to azure pipelines
* e71bf52 minor mod to branch triggers
* 513ba59 Updated to use trunk
* e8e940c Merge pull request #25 from glav/glav/LuisPackageBuild
* e688b2e Adding missing action into artifacts solution
* 8b6eafc Ensure Luis extension package gets created
* ab3f2b2 Remove redundant debugging step
* 579992e Merge pull request #24 from glav/glav/MinorTextChange
* f6372f5 Minor filter change to Code quality action triggers
* 9903115 Fixed type and fixed missing secrets from GH pipeline
* 95ce193 Very minor change
* d88946e Merge pull request #23 from glav/glav/SimpleLuisSupport
* 77119c8 Fixing test again

## Version: 1.1.0 [07/31/2020 15:47:48]
### New Items
* 39beb5c -Added Luis extension method GetIntents
* 4728f2e -Added LUIS documentation
* ecf42b6 -Added GetTopIntents extension for LUIS results and a test to verify
* c519571 -Added ability to supply number of request retries when creating config and double retry for face tests so they pass on the free tier
* c7e26f9 -Start simple LUIS support
### Bugfixes
* e71deee -Fixing typo of 'Warning'
### Full change list
* 9696658 Minor text removal
* 981ed4c Added a little bit more content to Wiki for LUIS extension
* 39beb5c NEW:Added Luis extension method GetIntents
* 58849d7 More Luis wiki additions
* 017d946 Wiki additions
* 4728f2e NEW:Added LUIS documentation
* 299251d Merge branch 'master' into glav/SimpleLuisSupport
* b6ec7d3 Merge pull request #22 from glav/glav/RemoveShiftLeftScan
* 406bfa3 Moved shiftleft analysis to a disabled folder to retain for education but not as a workflow
* ecf42b6 NEW:Added GetTopIntents extension for LUIS results and a test to verify
* d077184 Merge branch 'master' into glav/SimpleLuisSupport
* 4a165a5 Merge pull request #21 from glav/glav/TestWorkflowDispatch
* 78c4eeb Added workflow dispatch trigger
* 9b438d1 Added further test checks in Luis test
* 58c6706 Further cleanup in tests to remove test data
* d9c3073 Merge branch 'master' into glav/SimpleLuisSupport
* b2ddc4b Merge pull request #20 from glav/glav/EnableRetryCountConfiguration
* 9de3048 Refactored tests to ensure face actions are grouped logically. Tests pass on free tier but take more time.
* e71deee BUG:Fixing typo of 'Warning'
* 0f68c3f Adding large scale deletion of large person groups to clean up test data
* 30678ce Slight test refactor to ensure Face tests all use consistent config creation
* c519571 NEW:Added ability to supply number of request retries when creating config and double retry for face tests so they pass on the free tier
* 817ee0e Merge pull request #19 from glav/glav/TextAnalyticExtensionRefactor
* 709e9eb Simple cleanup
* a1ae3e5 The first passing integration test end to end
* 96cb24b Added Luis ConfigurationBuilderExtensions
* b059e00 Merge branch 'master' into glav/SimpleLuisSupport
* 2b37c87 Modified parsing to include intent score and reviewed property names, plus added more test checks
* 1e3e85e Remove commented code
* bc07e5a Added entitiy processing. Made tests pass. Need to fix entity model
* fcb723b Start to implement parsing. Is very different to others so setting up unit test on actual response data
* b21e011 Start to implement parsing. Is very different to others so setting up unit test on actual response data
* abff3f4 Changed name of test to properly reflect what it is
* 5209c6b Added impl for construction of Url endpoint and a passing test
* 3da5ad0 Minor cleanup
* 024390d I dunno :-)
* e83818d Add AnalysisEngine class impl
* 22638a1 Added AnalysisResults class
* 4628f07 Added ActionData and ActionDataItem class impl
* df0868e Begin adding context and response analysis classes, plus a contribution instructions (WIP) as I go along
* dc4596b Adding nuget package build to project config
* b78f17b Added some API response data items
* b67bc79 Adding custom config props for Luis API calls
* 945a4ec Removed commented code
* a3312f5 Added unit test and fixed so that unit test worked
* 8d7c834 Added basic config class support for LUIS
* c7e26f9 NEW:Start simple LUIS support
* c965248 Add in Luis project

## Version: 1.0.1 [07/07/2020 14:52:52]
### New Items
* 229a40c -Moved TextAnalytic extensions into the extensions package
### Bugfixes
* 544fa51 -Fixing memory issue and fixing tests
### Full change list
* 229a40c NEW:Moved TextAnalytic extensions into the extensions package
* 0819b64 Merge pull request #17 from glav/glav-security-scanning
* 65b1655 Setting check run action to neutral instead of action_required as it always fai;ls the build
* 0b8507f Try again
* 853f70f Reduce to one scan
* b9b6dc7 Revert to manual method
* 8b78661 I lied, another try
* 262708c One more try
* 91695eb Trying a custom action instead based from original
* bd35aa7 Trying diff syntax again
* b0b227a Trying diff syntax
* edd7e42 Using separate projects for each scan
* 784e413 Added other fluen API projects
* bf48587 Remving reports upload from original template
* 40e7423 Now try using a path
* 453bda2 Trying without the actual task, using command line
* ec278bc Damn yaml syntax
* d3de073 Try manual install of java dependency
* d9c3443 Try manual install of SL cli
* 9b43f72 Fixing stupid typo
* 838402a Adding Shiftleft access token and org ID to enable inspector
* 97d02ac Try explicit lang support
* ec83a4f Tried minor change to shiftleft scan
* 45d9c66 Added build option for shift left to work
* 9dd0c86 Merge branch 'master' into glav-security-scanning
* 590bade Merge pull request #18 from glav/glav-code-QL-scan
* 9d23fa1 Merge pull request #16 from glav/glav/DocumentationUpdate
* 9f582ee Create codeql-analysis.yml
* 9056d24 Create shiftleft-analysis.yml
* a7e3f2f Minor documentation update
* f44ca99 Merge pull request #14 from glav/MinorReadmeChange
* 1533d1d Update README.md
* 16e2345 Merge pull request #13 from glav/glav/RetryingNewSonarAction
* 651016b Trying newer dedicated SonarCloud action
* 672f0c2 Renaming GH action and trying update to Somarcloud azure devops task
* 578d053 Revert "Renaming GH action and trying update to Somarcloud azure devops task"
* e35c03d Renaming GH action and trying update to Somarcloud azure devops task
* 6c7a755 Update azure-pipelines.yml for Azure Pipelines
* 047f0f3 Merge pull request #12 from glav/glav/EnableIntegrationTestsOnActions
* 863286d Reverting silly config attempts
* 74bb56b Extra logging to determine issue with Azure DevOps
* 72d85ea Update azure-pipelines.yml for Azure Pipelines
* dc3ea64 Update azure-pipelines.yml for Azure Pipelines
* bd55647 Update azure-pipelines.yml for Azure Pipelines
* 71677f3 Update azure-pipelines.yml for Azure Pipelines
* 10397c9 Update azure-pipelines.yml for Azure Pipelines
* 8b82ce9 Update azure-pipelines.yml for Azure Pipelines
* f9dad70 Update azure-pipelines.yml for Azure Pipelines
* 08869db Silly mistake
* 17914a9 Now fixing azure devops
* aab91b5 Update azure-pipelines.yml for Azure Pipelines
* b97f765 Removed tokens from config in favour of using environment vars
* eb81ca5 Damn yaml syntax
* 6b0f78f testing workflow again
* 7637e04 testing workflow
* 5711f91 Again, more stupid errors.
* bf81b48 Stupid syntax mistake
* 29c9648 Forgot the dollar syntax
* 822ffbb Updated test config to use environment vars as well
* db066d4 Added integration tests and secrets to workflow
* a59f549 Merge pull request #11 from glav/glav/SyntaxAndCodeCleanup
* 37184c9 Merge pull request #10 from glav/glav/SonarcloudIntegration
* b0fd334 Minor path changes
* 8dc4045 Removed sonarcloud stuff as it doesn't work, added in tests to actions
* 614a2d0 reverting pattern and setting exlusions
* 6124d7e Trying different path for sonar checks
* 1cf94d5 Updated tests too
* afa66d0 Use proper version
* acfc6e7 Update .Net core installer and sdk downloaded
* 58e1473 Disable azure pipelines sonarqube run as it was not working
* fde4512 Trying the sonarcloud actions integration
* 3f8b720 Merge pull request #7 from glav/glav/IssueResponderAction
* d884ee3 Add in simple actions
* 90455ba Minor syntax change to use latest which cleans up code a bit
* 544fa51 BUG:Fixing memory issue and fixing tests

## Version: 1.0.0 [08/09/2019 17:58:57]
### Full change list
* 18aa305 Remove some more code smells
* efa2a0d More refactoring of code smells
* aed74d7 Remove code smell
* 48271a6 Removal of more code smells
* e2cc142 More code smell cleanup
* c19c819 Remove comment
* fe3e3c4 Remove more code smells
* b4255b1 Removed some code smells as per Sonarqube
* 91c7ab0 Update README.md
* d19d834 Fixing some code smells
* 0145885 Fixed cleanup deleting wrong file, removed intended one
* 9e3e6ff Ensure push in auto script
* 1768984 Cleanup

## Version: 0.9.2 [08/04/2019 13:37:26]
### New Items
* b50e833 -Addition of Face Identify API action
* 9c17a3e - Changes loggers to be async, also re-ordered face analytic calls to ensure deletes always worked
* 693782e -Added maximum retry config setting to honour rate limit response from service, extension method, implementation and updated documentation
* ca48810 -Added retry logic based on Retryheader when RateLimit exceeded, and new TraceLogger extension
* ca20c96 - Added support for LargePersonGroupTrain and TrainStatus
* 1df1dc1 -Adding support for LargePersonGroupPersonFaceDelete
* 731bf88 -Added initial support for LargePersonGroupPerson Face add functionality
* 582e54c -Adding support for LargePersonGroupPerson operations
* 06408cf -Initial adding of LargePersonGroupDelete support and refactoring for simpler largepersongroup code
* 7a525d9 - Amending IActionDataItem to support EndUriFragment for PersonGroup support
* 804086e - Modified Face API to support new API Action, removal of enum
* 347f4e5 - Major refactoring to Core, TextAnalytic and ComputerVision to support new form of APIActions, removal of Enum
* 331c534 -Refactoring to support LargePersonGroup Create and additional actions
* 5453d7c -Adding context, action and result classes for LargePersonGroup support
* b1a420f -Added PUT operation support in prep for LargePersonGroups functionality in Face API
* ee08997 -Addition of Face Identify API action
* b4aca76 - Changes loggers to be async, also re-ordered face analytic calls to ensure deletes always worked
* 0461b15 -Added maximum retry config setting to honour rate limit response from service, extension method, implementation and updated documentation
* c954814 -Added retry logic based on Retryheader when RateLimit exceeded, and new TraceLogger extension
* 960087a - Added support for LargePersonGroupTrain and TrainStatus
* a6f3d61 -Adding support for LargePersonGroupPersonFaceDelete
* e2412c8 -Added initial support for LargePersonGroupPerson Face add functionality
* 4e73029 -Adding support for LargePersonGroupPerson operations
* 7761c03 -Initial adding of LargePersonGroupDelete support and refactoring for simpler largepersongroup code
* cecf3e1 - Amending IActionDataItem to support EndUriFragment for PersonGroup support
* 175a048 - Modified Face API to support new API Action, removal of enum
* 51be3bf - Major refactoring to Core, TextAnalytic and ComputerVision to support new form of APIActions, removal of Enum
* f0ff582 -Refactoring to support LargePersonGroup Create and additional actions
* 498e302 -Adding context, action and result classes for LargePersonGroup support
* 65f266e -Added PUT operation support in prep for LargePersonGroups functionality in Face API
### Bugfixes
* dfff44c -Fixing flaw in logging that caused it not to log anything and setting log level had no effect
* 3770807 -Fixing flaw in logging that caused it not to log anything and setting log level had no effect
### Full change list
* 0f3c41b Fixed all the tests
* d6ab33f Fixing tests
* 9b02c65 Merge branch 'PersonGroupSupportUndelete' into glav/FixingBadApiKeyResponseErrors
* adcf02e minor comment change
* 82630a7 Version bump
* d132776 Merge branch 'PersonGroupSupportUndelete' of https://github.com/glav/CognitiveServicesFluentApi into PersonGroupSupportUndelete
* e0cab8f Added final set of tests to ensure largepersongroupperson error response parsing works
* ac7166a Fixed up remaining  LargePersonGroup error parsing issues
* 113039a Adding test around largepersongrouplist and made it pass
* a613a99 Adding test around largepersongroupget and made it pass
* d482355 Adding test around largepersongroupdelete and made it pass
* 1f5e415 Made the tests pass
* 8154039 Added fluent extension for FaceIdentification and fixed error respons parsing
* 9f4e88a Fixing test helper group face creation method
* 8707e5e Cleaned up computer vision stuff
* 6f6018d Fixing returning results to ensure we collect multiple call results
* e428324 Slightly modified image
* b50e833 NEW:Addition of Face Identify API action
* 504ff8b Cleanup
* 456f17c Refactoring TextAnalytics results using parsing strategy
* 8ad4dfc Added better response handling in result class after merge
* ac30a30 Added test to ensure response refactor still reflected error
* ead90b2 Splitting out classes and cleanup
* a77ff2f Fixing tests
* c22ae61 More major response parsing refactoring with parsing strategies - still WIP
* a805cbb Some more response parsing refactoring
* c2692c2 Refactored all the Face API results to use common base classes
* 9bd4b85 Add some extra logging and clean it up a bit
* 8cbd659 Fixing face training status bug not updating status when waiting and checking
* cb29a51 Continued refactor, making tests pass, implemented in a few result classes in face API
* 765f444 Started reactor for parsing strategy impl
* 9c17a3e NEW: Changes loggers to be async, also re-ordered face analytic calls to ensure deletes always worked
* dfff44c BUG:Fixing flaw in logging that caused it not to log anything and setting log level had no effect
* 693782e NEW:Added maximum retry config setting to honour rate limit response from service, extension method, implementation and updated documentation
* ca48810 NEW:Added retry logic based on Retryheader when RateLimit exceeded, and new TraceLogger extension
* c68cbeb Cleaning up test
* 9d0c0bd Added large integration test for training a face, and made it pass
* be2da41 Added more extension methods for LargePersonGroup Training and added further extensins for string to dates with tests
* ce2bb05 Added test for LargePersonGroupTrainStatus and made it pass
* ca20c96 NEW: Added support for LargePersonGroupTrain and TrainStatus
* 33fa23d Added test for face delete and made it pass
* 1df1dc1 NEW:Adding support for LargePersonGroupPersonFaceDelete
* 23c5982 Added test, made it pass
* f751b6d Completed LargePresonGroupPersonFaceGet impl and some refactoring
* 7d83bec Added unit test for LargePersonGroup Add face
* e8fcd80 Adding extra support for person face add data submission and result assignment
* 731bf88 NEW:Added initial support for LargePersonGroupPerson Face add functionality
* d597d40 Added integration tests and made them work
* fbe0fa3 Adding in Face Wiki merge fixes
* 5f7981c Added LargePersonGroupCreate test
* 7d29ec0 Test cleanup
* 9d33355 Added test around LargePersonGroupPersonList and made test work
* 2590282 Made tests pass
* b3695f8 Added LargePersonGroupPerson Create test and renamed LargePersonGroup test to be more appropriate
* 010ad71 Completed impl for LargePersonGroupPerson and added initial test
* 65a3722 Added missing method impl for PersonGroupPerson delete
* 65579c1 Adding analysis context for LargePersonGroupPerson actions
* 8412f56 Adding LargePersonGroupPerson response structures
* 582e54c NEW:Adding support for LargePersonGroupPerson operations
* ac85f8a Refactored to use common error response class
* 8d80e0c Fixed other extension method
* 012ea32 Little bit of grouping, added extension method, fixed test
* 31347da Added test and made it pass for LargePersonGroupDelete
* 5d2c3f7 Added relevant config for LargePersonGroupDelete
* 06408cf NEW:Initial adding of LargePersonGroupDelete support and refactoring for simpler largepersongroup code
* 3738552 Made the tests work
* 86d0edb Minor addition of some validation
* 16a0870 Added fluent extension for LargePersonGroupGet/List
* b908dac Minor refactoring - extracted classes into separate files
* 0adc773 Added test for LargePersonGroupList and minor refactor
* c445b73 Added separate LargepersonGroupList action data to support specific parameters
* 836bec1 Fixed large person group get and ensured tests pass
* 7a525d9 NEW: Amending IActionDataItem to support EndUriFragment for PersonGroup support
* f6bba63 Adding test and cleanup to ensure support for additional Uri fragments to allow PersonGroup functionality to work
* 1bb1040 Adding some documentation
* 4686ddd Massive refactor to support proper API definition and more flexible HTTP backend
* 12e90ee Cleaned up communications engine with simplified structure and new APIActionDefinition support. All tests actually pass!
* 1280425 Fixed all Unit tests
* c6be7db Fixing some unit tests
* 804086e NEW: Modified Face API to support new API Action, removal of enum
* 347f4e5 NEW: Major refactoring to Core, TextAnalytic and ComputerVision to support new form of APIActions, removal of Enum
* 331c534 NEW:Refactoring to support LargePersonGroup Create and additional actions
* 5453d7c NEW:Adding context, action and result classes for LargePersonGroup support
* b1a420f NEW:Added PUT operation support in prep for LargePersonGroups functionality in Face API
* d66687e Fixing Wiki merge conflicts
* 642cddb Adding test to simulate bad API key
* 60ed8e5 Changed directory structure only. Removed empty/nested project dir
* 1ffa4cb Added final set of tests to ensure largepersongroupperson error response parsing works
* 5e5ac4d Fixed up remaining  LargePersonGroup error parsing issues
* 9747e73 Adding test around largepersongrouplist and made it pass
* 4b5f003 Adding test around largepersongroupget and made it pass
* 58577ea Adding test around largepersongroupdelete and made it pass
* 99e8c0b Made the tests pass
* 0cace33 Added fluent extension for FaceIdentification and fixed error respons parsing
* c8d2342 Fixing test helper group face creation method
* 3909178 Cleaned up computer vision stuff
* 6845da1 Fixing returning results to ensure we collect multiple call results
* eba9dae Slightly modified image
* ee08997 NEW:Addition of Face Identify API action
* b798614 Cleanup
* 4e29c30 Refactoring TextAnalytics results using parsing strategy
* 5344ec2 Added better response handling in result class after merge
* 813c7ed Added test to ensure response refactor still reflected error
* e568f4f Splitting out classes and cleanup
* a1ba5c0 Fixing tests
* 6fe43de More major response parsing refactoring with parsing strategies - still WIP
* abcd9f4 Some more response parsing refactoring
* 036562f Refactored all the Face API results to use common base classes
* f2afaed Add some extra logging and clean it up a bit
* 94e496a Fixing face training status bug not updating status when waiting and checking
* 050251b Continued refactor, making tests pass, implemented in a few result classes in face API
* fed29e1 Started reactor for parsing strategy impl
* b4aca76 NEW: Changes loggers to be async, also re-ordered face analytic calls to ensure deletes always worked
* 3770807 BUG:Fixing flaw in logging that caused it not to log anything and setting log level had no effect
* 0461b15 NEW:Added maximum retry config setting to honour rate limit response from service, extension method, implementation and updated documentation
* c954814 NEW:Added retry logic based on Retryheader when RateLimit exceeded, and new TraceLogger extension
* 6198515 Cleaning up test
* c62a6a7 Added large integration test for training a face, and made it pass
* e8850e2 Added more extension methods for LargePersonGroup Training and added further extensins for string to dates with tests
* 60806ac Added test for LargePersonGroupTrainStatus and made it pass
* 960087a NEW: Added support for LargePersonGroupTrain and TrainStatus
* 7ede3bd Added test for face delete and made it pass
* a6f3d61 NEW:Adding support for LargePersonGroupPersonFaceDelete
* 8f28b5e Added test, made it pass
* fab9ff9 Completed LargePresonGroupPersonFaceGet impl and some refactoring
* 0a2968e Added unit test for LargePersonGroup Add face
* cdb01c4 Adding extra support for person face add data submission and result assignment
* e2412c8 NEW:Added initial support for LargePersonGroupPerson Face add functionality
* 2502d3a Added integration tests and made them work
* c6f1d87 Wiki changes
* a4e1d10 Added LargePersonGroupCreate test
* 53b1a42 Test cleanup
* b3c7028 Added test around LargePersonGroupPersonList and made test work
* 989f716 Made tests pass
* 9ff926a Added LargePersonGroupPerson Create test and renamed LargePersonGroup test to be more appropriate
* 6062cc4 Completed impl for LargePersonGroupPerson and added initial test
* a022b24 Added missing method impl for PersonGroupPerson delete
* c7dedfe Adding analysis context for LargePersonGroupPerson actions
* 8a9ddf4 Adding LargePersonGroupPerson response structures
* 4e73029 NEW:Adding support for LargePersonGroupPerson operations
* 57eeb96 Refactored to use common error response class
* d2eb156 Fixed other extension method
* e2a496d Little bit of grouping, added extension method, fixed test
* 0ad2ccb Added test and made it pass for LargePersonGroupDelete
* 1c91937 Added relevant config for LargePersonGroupDelete
* 7761c03 NEW:Initial adding of LargePersonGroupDelete support and refactoring for simpler largepersongroup code
* b09b3c0 Made the tests work
* d5d76b6 Minor addition of some validation
* 76c0d20 Added fluent extension for LargePersonGroupGet/List
* bf8af46 Minor refactoring - extracted classes into separate files
* 20b430d Added test for LargePersonGroupList and minor refactor
* 819c151 Added separate LargepersonGroupList action data to support specific parameters
* 3511a64 Fixed large person group get and ensured tests pass
* cecf3e1 NEW: Amending IActionDataItem to support EndUriFragment for PersonGroup support
* 4946c91 Adding test and cleanup to ensure support for additional Uri fragments to allow PersonGroup functionality to work
* 4323e93 Adding some documentation
* 31ddccb Massive refactor to support proper API definition and more flexible HTTP backend
* 5ebc982 Cleaned up communications engine with simplified structure and new APIActionDefinition support. All tests actually pass!
* 8c3aafd Fixed all Unit tests
* 01a8627 Fixing some unit tests
* 175a048 NEW: Modified Face API to support new API Action, removal of enum
* 51be3bf NEW: Major refactoring to Core, TextAnalytic and ComputerVision to support new form of APIActions, removal of Enum
* f0ff582 NEW:Refactoring to support LargePersonGroup Create and additional actions
* 498e302 NEW:Adding context, action and result classes for LargePersonGroup support
* 65f266e NEW:Added PUT operation support in prep for LargePersonGroups functionality in Face API

## Version: 0.9.1 [07/26/2019 18:41:07]
### New Items
* e4e6346 -Created separate extension packages to separate out extension/convenience methods from core API functionality
### Full change list
* c1e6fd9 Getting final extension method in for computer vision in Wiki
* 7e0fdea Updated face and computer vision wiki
* d3b3e43 Updated Wiki and a little more refactoring
* 5299959 version bump to 0.9.1
* d4441e6 Minor addition of method info
* f64f6fb Slight refactoring
* 4b1c40a Minor documentation update
* 85353ac Minor update to Wiki formatting
* f15ad24 Updates to the Wiki for new packages
* 6b878a9 Moved the Face and TextAnalytics extensions into the new package projects
* e03b570 Moved ComputerVision extensions into the new package project
* e4e6346 NEW:Created separate extension packages to separate out extension/convenience methods from core API functionality
* ec0d75e Merge branch 'master' of https://github.com/glav/CognitiveServicesFluentApi
* 75f8bc0 Taking out manual intervention - just doesn't work with YAML pipelines
* 4c6447d Trying manual intervention again in earlier stage
* 5ce01a0 Trying manual intervention again
* 84e936d Change to pipeline artifacts for build/release pipeline
* e7ae2a5 Update tagging/release script to ensure tags are also pushed
* d445ebc Using internal feed for now
* 06f79e9 Using internal feed for now
* d17c5ca Trying to get manual intervention to work again 3
* 0f7e985 Trying to get manual intervention to work again
* e191fde Trying to get manual intervention to work
* f76e321 Updated manual intervention
* 07ee56f Added manual step before deploy to nuget - as job no agent
* b391865 Added manual step before deploy to nuget
* e839b62 Adding basic deploy stage - WIP
* 1175d8b Update azure-pipelines.yml for Azure Pipelines
* 13d5183 Update azure-pipelines.yml for Azure Pipelines
* 371c6f1 Update azure-pipelines.yml for Azure Pipelines
* 644a28e Update azure-pipelines.yml for Azure Pipelines
* 0760622 Simple Job text change
* 48ec3ab Merge branch 'master' of https://github.com/glav/CognitiveServicesFluentApi
* 8f32d52 Modified test to suit to results from updated service
* 8da15fb Attempt to fix parsing issue 4
* 08b0469 Attempt to fix sonarqube parsing issue 3
* 74227f0 Attempt to fix sonarqube parsing issue 2
* 2162704 Attempt to fix sonarqube parsing issue
* 45a93d5 Attempt ti fix sonarqube parsing issue
* 14235a4 Removed API keys - stoopid
* 7ff1b7f Update azure-pipelines.yml for Azure Pipelines
* 5dfffde Adding back build config
* 482092f Move Project board link to bottom of doc
* 6fae7b9 Added link to Azure DevOps project board
* 93093fb Update azure-pipelines.yml for Azure Pipelines
* f78fbbd Added variables/api keys
* c0c635b Update azure-pipelines.yml for Azure Pipelines
* 7e79835 Update azure-pipelines.yml for Azure Pipelines
* bbcaef4 Set up CI with Azure Pipelines
* b581d7c Fixing some code smells

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
