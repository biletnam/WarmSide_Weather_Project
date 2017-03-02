# Variables initialization
.  .\Scripts\Deploy_config.ps1;

# Function declaration
.  .\Scripts\Deploy_functions.ps1

ValidatePaths;
RestoreNugetPackages;
Build;
Deploy;
CheckWebSiteStatus;






