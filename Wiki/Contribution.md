= [Home](/README.md)/Contribution

### This section is VERY incomplete - WIP

If you want to add a new integration with a new cognitive service

* Create a new project
* Glav.CognitiveServices.FluentApi.{cognitive service}
* Add reference to Core project
* Start with the 'Configuration' directory/elements (ApiConstants, ApiServiceUriCollection, *ServiceCOnfig classes)
* Add in 'Domain' directory starting with ApiOperations
* Add in ApiResponses to Domain namespace
* Do AnalysisResult class and AnalysisContext in Domain namespace
* Add ActionData and ActionDataItem class(es)
* Add AnalysisResults class(es)

