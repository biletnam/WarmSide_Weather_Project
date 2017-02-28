# Set service variables
. .\Scripts\Deploy_config.ps1;

# Testing paths 
$nugetExists = Test-Path $nugetPath;
$msbuildExists = Test-Path $msbuildPath;
$projectPathExists = Test-Path $projectPath;

if (!$nugetExists -or !$msbuildExists -or !$projectPathExists)
{
    throw [System.Exception] "Not all necessary paths exist"
}


# Create or clear temp folder
New-Item -ItemType Directory -Force -Path $tempFolder | Out-Null;
Remove-Item ($tempFolder + "\*");

# Restore Nuget packages
& $nugetPath restore ($projectPath) -noninteractive;

# Build solution
& $msbuildPath $projectPath /p:OutputPath=$tempFolder;


# If website in IIS doesn't exist, create new one with specified parameters

if ((Get-Website -Name $webSiteName) -eq $null)
{
    Write-Host "Website doesn't exist. Creating new one...";

    # Creating folder in IIS
    New-Item -ItemType Directory -Force -Path $webSitePath;
    
    # Creating WebAppPool and WebSite
    New-WebAppPool $appPoolName;
    New-WebSite -Name $webSiteName -Port $webSitePort  -ApplicationPool $appPoolName -PhysicalPath $webSitePath;

    # Deploying website
    Copy-Item -Path ($tempFolder + "\*") -Destination $webSitePath -recurse -Force;

    # Starting WebAppPool and WebSite
    Start-WebAppPool -Name $appPoolName;
    Start-Website -Name $webSiteName;

    Write-Host "Website was successfully created and deployed!";
}
#If website in IIS already exists, deploy new build
else
{
    Write-Host "Website exists";

    # Stopping WebAppPool and WebSite
    Stop-Website -Name $webSiteName;
    Stop-WebAppPool -Name $appPoolName;

    # Deploying WebSite
    $currentWebSitePath = (Get-Website -Name $webSiteName).physicalPath;
    Copy-Item -Path ($tempFolder + "\*") -Destination "$currentWebSitePath" -recurse -Force;

    # Starting WebAppPool and WebSite
    Start-WebAppPool -Name $appPoolName;
    Start-Website -Name $webSiteName;

    Write-Host "Website was successfully deployed!";
}

# Checking if the WebSite works

$HTTP_Request = [System.Net.WebRequest]::Create("http://localhost:$webSitePort")

$HTTP_Response = $HTTP_Request.GetResponse()

$HTTP_Status = [int]$HTTP_Response.StatusCode

If ($HTTP_Status -eq 200) 
{ 
    Write-Host "Site is OK!" 
}
Else 
{
    Write-Host "The Site may be down, please check!"
}
$HTTP_Response.Close()






