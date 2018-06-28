param( [# Next version number
Parameter(Mandatory=$true)]
[string]
$newVersion)
#This script will get last tag from HEAD backwards in history
#So, it will list from HEAD, each commit up until a current TAG is encountered in the commit history
# see https://discuss.bitrise.io/t/how-to-generate-release-notes-changelog-from-git-commits-since-last-git-tag/2941

$scriptPath = Get-Location
$filePath = "$scriptPath\..\Wiki\ReleaseNotes.md"
$priorReleaseNotes = ""

#Get the last tag
$lastTag = git describe --tags --abbrev=0
"Last tag in history from HEAD is [$lastTag]"

#Get the commits from HEAD up until the last tag
$releaseNotes = git log "$lastTag..HEAD" --pretty=format:"%h %s"

function createIfNotExist
{
    new-item -Path $filePath -ErrorAction Ignore >$null
}

function extractLines($token)
{
  $releaseNotes | ForEach-Object { if ($_ -match $token) { Write-Output $_.Replace($token,"-")} }
}

function addToFile($heading, $content)
{
  if ($content) {
    Add-Content -Path $filePath -value "### $heading"
    $content | ForEach-Object { Add-Content -Path $filePath -value ("* " + $_) }
  }
 
}

#Create the release notes file if does not already exist
createIfNotExist

#Using the git commit history, extract out any commits with NEW: and BUGFIX: as the commit message
$newChanges = extractLines "NEW:"
$bugFixes = extractLines "BUGFIX:"

#Get any existing contents to write to the bottom of the file later as we want the latest changes at the top
$priorReleaseNotes = Get-Content $filePath 


#Kill existing file
Remove-Item $filePath

#Write the header
Add-Content -Path $filePath -value ""
Add-Content -Path $filePath -value "## Version: $newVersion [$(Get-Date)]"

#Write the latest changes into the release notes file
addToFile "New Items" $newChanges
addToFile "Bugfixes" $bugFixes
addToFile "Full change list" $releaseNotes

#Write the existing set of release notes
Add-Content -Path $filePath -Value $priorReleaseNotes

$releaseTag = "Release_$newVersion"

#Now stage the changes (primarily ReleaseNotes), update the repo
git add -A
got commit -m "Updated release notes for $releaseTag"

## finish up by tagging the git repo and push it
git tag -a "$releaseTag" -m "Release $newVersion"
git push



