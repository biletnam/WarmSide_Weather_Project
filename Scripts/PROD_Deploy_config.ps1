# This is configuration script where all variables are set

# Service variables
$nuget = 'C:\PowerShellBuild\nuget.exe';
$msbuild = 'C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe';
$installutil = 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\installutil.exe';
$rootFolder = ''; #..\
$warmSideWebSitePath = $rootFolder + 'WarmSide\WarmSide.sln';
$warmSideBuildFolder = $rootFolder + 'Publish';
$loggingServiceProjectPath = $rootFolder + 'LoggingService\LoggingService.sln';
$loggingServiceBuildFolder = 'C:\LoggingService';
$loggingServiceExeName = 'LoggingService.WindowsServiceHost.exe';
$loggingServiceName = 'LoggingWindowsService';

# New WebFace site properties
$webFaceAppPoolName = "WarmSideWebFace";
$webFaceSiteName = "WarmSideWebFace";
$webFaceSitePath = 'C:\inetpub\wwwroot\WarmSideWebFace';
$webFaceSitePort = 83;

# New WebApi site properties
$webApiAppPoolName = "WarmSideWebApi";
$webApiSiteName = "WarmSideWebApi";
$webApiSitePath = 'C:\inetpub\wwwroot\WarmSideWebApi';
$webApiSitePort = 86;

Write-Host "Variables were set"