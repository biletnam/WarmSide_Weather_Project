# Initializes all variables and validates paths
function ValidatePaths
{
	# Set service variables
	. .\Scripts\Deploy_config.ps1;
	
	$nugetExists = Test-Path $nuget;
	$msbuildExists = Test-Path $msbuild;
	$projectPathExists = Test-Path $projectPath;
	
	# Testing paths 
	if (!$nugetExists)
	{
		throw [System.Exception] "Nuget application does not exist on the specified path."
	}

	if (!$msbuildExists)
	{
		throw [System.Exception] "MSBuild application does not exist on the specified path."
	}

	if (!$projectPathExists)
	{
		throw [System.Exception] "Target project does not exist on the specified path."
	}
}

# Restores Nuget packages
function RestoreNugetPackages
{
	& $nuget restore ($projectPath) -noninteractive;
}

# Builds solution
function Build
{
	# Create or clear temp folder
	New-Item -ItemType Directory -Force -Path $tempFolder | Out-Null;
	Remove-Item -Path ($tempFolder + "\*") -Force;
	
	& $msbuild $projectPath /t:Build /p:Configuration=Release /p:OutputPath=$tempFolder ;
}

# Deploys project to IIS using specified parameters
function Deploy
{
	if ((Get-Website -Name $webSiteName) -eq $null)
	{
		Write-Host "Website doesn't exist. Creating new one...";
		
		# Creating folder in IIS
		New-Item -ItemType Directory -Force -Path $webSitePath;
		
		# Creating WebAppPool and WebSite
		New-WebAppPool $appPoolName;
		New-WebSite -Name $webSiteName -Port $webSitePort  -ApplicationPool $appPoolName -PhysicalPath $webSitePath;

		# Deploying website
		Copy-Item -Path ($tempFolder + "\_PublishedWebsites\" + $webSiteName + "\*") -Destination $webSitePath -recurse -Force;

		# Starting WebAppPool and WebSite
		StartStopWebAppPool -action Stop -poolName $appPoolName;
		Start-Website -Name $webSiteName;

		Write-Host "Website was successfully created and deployed!";
	}
	
	#If website in IIS already exists, deploy new build
	else
	{
		Write-Host "Website exists";

		# Stopping WebAppPool and WebSite
		Stop-Website -Name $webSiteName;
		StartStopWebAppPool -action Stop -poolName $appPoolName;

		# Deploying WebSite
		$currentWebSitePath = (Get-Website -Name $webSiteName).physicalPath;
		Copy-Item -Path ($tempFolder + "\_PublishedWebsites\" + $webSiteName + "\*") -Destination "$currentWebSitePath" -recurse -Force;
		
		StartStopWebAppPool -action Start -poolName $appPoolName;
		Start-Website -Name $webSiteName;

		Write-Host "Website was successfully deployed!";
	}
}

# Checks if the WebSite works
function CheckWebSiteStatus
{
	If ((Invoke-WebRequest "http://localhost:$webSitePort").StatusCode -eq 200) 
	{ 
		Write-Host "Site is OK!" 
	}
	Else 
	{
		Write-Host "The Site may be down, please check!"
		return -1;
	}
}

function StartStopWebAppPool($action, $poolName)
{
	if ($action -eq "Start")
	{
		if ( (Get-WebAppPoolState -Name $poolName).Value -eq "Started")
			{
				Write-Host "AppPool already started " + $poolName
			}
			else
			{
				Write-Host "Starting the AppPool: " + $poolName
				Write-Host (Get-WebAppPoolState $poolName).Value

				Start-WebAppPool -Name $poolName
			}

			do
			{
				Write-Host (Get-WebAppPoolState $poolName).Value
				Start-Sleep -Seconds 1
			}
			until ( (Get-WebAppPoolState -Name $poolName).Value -eq "Started" )
	}
	elseif ($action -eq "Stop")
	{
		if ( (Get-WebAppPoolState -Name $poolName).Value -eq "Stopped" )
			{
				Write-Host "AppPool already stopped: " + $poolName
			}
			else
			{
				Write-Host "Shutting down the AppPool: " + $poolName
				Write-Host (Get-WebAppPoolState $poolName).Value

				Stop-WebAppPool -Name $poolName
			}

			do
			{
				Write-Host (Get-WebAppPoolState $poolName).Value
				Start-Sleep -Seconds 1
			}
			until ( (Get-WebAppPoolState -Name $poolName).Value -eq "Stopped" )
	}
	else
	{
		Write-Host "Invalid parameter: " + $action;
		return;
	}
}

ValidatePaths;
RestoreNugetPackages;
Build;
Deploy;
CheckWebSiteStatus;






