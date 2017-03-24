$ErrorActionPreference = 'Stop';

# Variables initialization
if($args[0] -eq 'PROD')
{
	.  .\Scripts\PROD_Deploy_config.ps1;
}
elseif($args[0] -eq 'DEV')
{
	.  .\Scripts\DEV_Deploy_config.ps1;
}
else
{
	throw [System.Exception] "Invalid argument $args[0]. Either PROD or DEV is accepted."
	retutn;
}

# Function declaration
.  .\Scripts\Deploy_functions.ps1
#ValidatePaths $nuget $msbuild
#RestoreNugetPackages $nuget $warmSideWebSitePath
#BuildProject $warmSideWebSitePath "..\..\$warmSideBuildFolder"
#DeployWebSite $webSiteName $webSitePort $appPoolName $webSitePath $warmSideBuildFolder
#CheckWebSiteStatus "http://localhost:$webSitePort"
RestoreNugetPackages $nuget $loggingServiceProjectPath
BuildProject $loggingServiceProjectPath $loggingServiceBuildFolder
DeployLoggingService $loggingServiceBuildFolder $loggingServiceExeName;






