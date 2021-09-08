# Only an example of a SonarCloud build
dotnet sonarscanner begin /k:$projkey /d:sonar.login=$token /o:"glav-github" /d:sonar.host.url="https://sonarcloud.io"
dotnet build .\Glav.CognitiveServices.Api.sln
del .\sonar-project.properties

# Need to ensure this is Java11 or wont work
# The version of Java (1.8.0-25) you have used to run this analysis is deprecated and we stopped accepting it.
# Please update to at least Java 11. You can find more information here: https://sonarcloud.io/documentation/upcoming/
$env:JAVA_HOME="C:\Program Files\Android\jdk\microsoft_dist_openjdk_1.8.0.25"
dotnet sonarscanner end /d:sonar.login=$token
 