# Functions used in build and deployment scripts.
# Require the following global variables to be set:
#
# Service variables:
# $nuget - Nuget path
# $msbuild - MSBuild path
# $rootFolder - script root folder path
# $projectPath - project path
# $buildFolder = build folder path

# New site properties:
# $appPoolName - name of appPool that is created for the project
# $webSiteName - name of webSite that is created for the project
# $webSitePath - path of webSite that is created for the project
# $webSitePort - port number of webSite that is created for the project

# Builds solution
function Build
{
	# Create or clear Publish folder
	New-Item -ItemType Directory -Force -Path $buildFolder | Out-Null;
	Remove-Item -Path ($buildFolder + "\*") -Force;

	& $msbuild $projectPath /t:Build /p:Configuration=Release /p:OutputPath=$buildFolder;
}

# Checks if created WebSite works
function CheckWebSiteStatus
{
	If ((Invoke-WebRequest "http://localhost:$webSitePort").StatusCode -eq 200) 
	{ 
		Write-Host "Site is OK!" 
	}
	Else 
	{
		Write-Host "The Site may be down, please check!"
	}
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
        Set-Location '..\..\'
		# Deploying website
		Copy-Item -Path ($buildFolder + "\_PublishedWebsites\" + $webSiteName + "\*") -Destination $webSitePath -recurse -Force;

		# Starting WebAppPool and WebSite
		StartStopWebAppPool -action Start -poolName $appPoolName;
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
		Copy-Item -Path ($buildFolder + "\_PublishedWebsites\" + $webSiteName + "\*") -Destination "$currentWebSitePath" -recurse -Force;
		
		# Starting WebAppPool and WebSite
		StartStopWebAppPool -action Start -poolName $appPoolName;
		Start-Website -Name $webSiteName;

		Write-Host "Website was successfully deployed!";
	}
}

# Restores Nuget packages in project
function RestoreNugetPackages
{
	& $nuget restore ($projectPath) -noninteractive;
}

# Starts or stops WebAppPool
function StartStopWebAppPool($action, $poolName)
{
	$counter = 0;
	
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
				$counter++; 
				if ($counter -eq 60)
				{
					throw [System.Exception] "Cannot $action $poolName webAppPool!"
				}
				Start-Sleep -Seconds 1
			}
			until (((Get-WebAppPoolState -Name $poolName).Value -eq "Started"))
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
				$counter++; 
				
				if ($counter -eq 60)
				{
					throw [System.Exception] "Cannot $action $poolName webAppPool!"
				}
				
				Start-Sleep -Seconds 1
			}
			until ((Get-WebAppPoolState -Name $poolName).Value -eq "Stopped")
	}
	else
	{
		Write-Host "Invalid parameter: " + $action;
	}
}

# Tests project and tools paths
function ValidatePaths
{
	if (!(Test-Path $nuget))
	{
		throw [System.Exception] "Nuget application does not exist on the specified path: $nuget"
	}

	if (!(Test-Path $msbuild))
	{
		throw [System.Exception] "MSBuild application does not exist on the specified path: $msbuild"
	}

	if (!(Test-Path $projectPath))
	{
		throw [System.Exception] "Target project does not exist on the specified path: $projectPath"
	}
}









