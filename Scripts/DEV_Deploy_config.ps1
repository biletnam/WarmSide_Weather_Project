# This is configuration script where all variables are set

# Service variables
$nuget = 'D:\PowerShellSandbox\nuget.exe';
$msbuild = 'C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe';
$installutil = 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\installutil.exe';
$rootFolder = ''; #..\
$warmSideWebSitePath = $rootFolder + 'WarmSide\WarmSide.sln';
$warmSideBuildFolder = $rootFolder + 'Publish';
$loggingServiceProjectPath = $rootFolder + 'LoggingService\LoggingService.sln';
$loggingServiceBuildFolder = 'C:\LoggingService';
$loggingServiceExeName = 'LoggingService.WindowsServiceHost.exe';
$loggingServiceName = 'LoggingWindowsService';

# New site properties
$appPoolName = "WarmSide";
$webSiteName = "WarmSide";
$webSitePath = 'C:\inetpub\wwwroot\WarmSide';
$webSitePort = 83;

Write-Host "Variables were set"