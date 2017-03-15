# This is configuration script where all variables are set

# Service variables
$nuget = 'D:\PowerShellSandbox\nuget.exe';
$msbuild = 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe';
$rootFolder = ''; #..\
$projectPath = $rootFolder + 'WarmSide\WarmSide.sln';
$buildFolder = $rootFolder + 'Publish';

# New site properties
$appPoolName = "WarmSide";
$webSiteName = "WarmSide";
$webSitePath = 'C:\inetpub\wwwroot\WarmSide';
$webSitePort = 80;

Write-Host "Variables were set"