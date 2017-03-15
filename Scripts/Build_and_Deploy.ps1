$ErrorActionPreference = 'Stop';

Write-Host $PSScriptRoot
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

ValidatePaths;
RestoreNugetPackages;
Build;
Deploy;
CheckWebSiteStatus;






