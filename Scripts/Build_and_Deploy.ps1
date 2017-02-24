clear;

# Build sources properties
$sourcesPath = 'C:\PowerShellBuild\Sources\'; # 'D:\WebPlayer\';
$webSiteFolderName = 'WarmSide'; # 'WebPlayer';

# Service variables
$buildPath = 'C:\PowerShellBuild\Build\';
$nugetPath = 'C:\PowerShellBuild\nuget.exe';
$msbuildPath = 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe'

# New site properties
$appPoolName = $webSiteFolderName;
$webSiteName = $webSiteFolderName;
$webSitePath = 'C:\inetpub\wwwroot\Player';
$webSitePort = 80;

#Install-Module -Name Invoke-MsBuild -RequiredVersion 2.1.0

# Copy sources to Build folder
Copy-Item -Path "$sourcesPath*" -Destination $buildPath -recurse -Force;

# Find .sln file path
$solutionFilePath = $buildPath + $webSiteFolderName + "\" + (Get-ChildItem -Path ($buildPath + $webSiteFolderName) -Filter *.sln | Select-Object -First 1).name

# Restore Nuget packages
& $nugetPath restore ($solutionFilePath) -noninteractive;


# Build solution
& $msbuildPath $solutionFilePath;

#$buildSucceeded = Invoke-MsBuild -Path $solutionFilePath;
#
#if ($buildSucceeded)
#{ 
#    Write-Host "Build completed successfully."; 
#}
#else
#
#{
#   Write-Host "Build failed. Check the build log file for errors.";
#}

# If website in IIS doesn't exist, create new one with specified parameters

if ((Get-Website -Name $webSiteName) -eq $null)
{
    New-Item -ItemType Directory -Force -Path $webSitePath;
    Write-Host "Website doesn't exist. Creating new one...";
    New-WebAppPool $appPoolName;
    New-WebSite -Name $webSiteName -Port $webSitePort  -ApplicationPool $appPoolName -PhysicalPath $webSitePath;
    Copy-Item -Path ($buildPath + $webSiteFolderName + "\" + $webSiteFolderName + "\*") -Destination $webSitePath -recurse -Force;
    Restart-WebItem -PSPath "IIS:\Sites\$webSiteName";
    Write-Host "Website was successfully created and deployed!";
}
#If website in IIS already exists, deploy new build
else
{
    Write-Host "Website exists";
    Stop-Website -Name $webSiteName;
    Stop-WebAppPool -Name $appPoolName;
    $currentWebSitePath = (Get-Website -Name $webSiteName).physicalPath;
    Copy-Item -Path ($buildPath + $webSiteFolderName + "\*") -Destination "$currentWebSitePath" -recurse -Force;
    Start-WebAppPool -Name $appPoolName;
    Start-Website -Name $webSiteName;
    Write-Host "Website was successfully deployed!";
}

# Checking if site works

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






