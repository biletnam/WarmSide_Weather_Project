# This is configuration script where all variables are set

# Service variables
$nuget = 'C:\PowerShellBuild\nuget.exe';
$msbuild = 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe';
$rootFolder = ''; #..\
$warmSideWebSitePath = $rootFolder + 'WarmSide\WarmSide.sln';
$warmSideBuildFolder = $rootFolder + 'Publish';
$loggingServiceProjectPath = $rootFolder + 'LoggingService';
$loggingServiceBuildFolder = 'C:\LoggingService';
$loggingServiceExeName = 'LoggingService.WindowsServiceHost.exe';

# New site properties
$appPoolName = "WarmSide";
$webSiteName = "WarmSide";
$webSitePath = 'C:\inetpub\wwwroot\WarmSide';
$webSitePort = 86;

Write-Host "Variables were set"