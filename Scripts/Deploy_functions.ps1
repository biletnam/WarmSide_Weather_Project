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
function BuildProject($projectPath, $buildDir)
{
	# Create or clear Publish folder
	New-Item -ItemType Directory -Force -Path $buildDir | Out-Null;
	Remove-Item -Path ($buildDir + "\*") -Recurse;

	& $msbuild $projectPath /t:Build /p:Configuration=Release /p:OutputPath=$buildDir;
	if($LastExitCode -ne 0)
	{
		throw [System.Exception] "Project $projectPath build failed."
	}
}

# Checks if created WebSite works
function CheckWebSiteStatus($siteUrl)
{
	If ((Invoke-WebRequest "$siteUrl").StatusCode -eq 200) 
	{ 
		Write-Host "Site is OK!" 
	}
	Else 
	{
		Write-Host "The Site may be down, please check!"
	}
}

# Deploys project to IIS using specified parameters
function DeployWebSite($siteName, $sitePort, $poolName, $sitePath, $siteBuildDir)
{
	if ((Get-Website -Name $siteName) -eq $null)
	{
		Write-Host "Website doesn't exist. Creating new one...";
		
		# Creating folder in IIS
		New-Item -ItemType Directory -Force -Path $webSitePath;
		
		# Creating WebAppPool and WebSite
		New-WebAppPool $poolName;
		New-WebSite -Name $siteName -Port $sitePort  -ApplicationPool $poolName -PhysicalPath $sitePath;
		# Deploying website
		Copy-Item -Path ($siteBuildDir + "\_PublishedWebsites\" + $siteName + "\*") -Destination $sitePath -recurse -Force;

		# Starting WebAppPool and WebSite
		StartStopWebAppPool -action Start -poolName $poolName;
		Start-Website -Name $siteName;

		Write-Host "Website was successfully created and deployed!";
	}
	
	#If website in IIS already exists, deploy new build
	else
	{
		Write-Host "Website exists";

		# Stopping WebAppPool and WebSite
		Stop-Website -Name $siteName;
		StartStopWebAppPool -action Stop -poolName $poolName;

		# Deploying WebSite
		$currentWebSitePath = (Get-Website -Name $siteName).physicalPath;
		Copy-Item -Path ($siteBuildDir + "\_PublishedWebsites\" + $siteName + "\*") -Destination "$currentWebSitePath" -recurse -Force;
		
		# Starting WebAppPool and WebSite
		StartStopWebAppPool -action Start -poolName $poolName;
        Write-Host $siteName
		Start-Website -Name $siteName;

		Write-Host "Website was successfully deployed!";
	}
}

# Restores Nuget packages in project
function RestoreNugetPackages($nuget, $projectDir)
{
	& $nuget restore ($projectDir) -noninteractive;
}

# Starts or stops WebAppPool
function StartStopWebAppPool($action, $poolName)
{
	$counter = 0;
	
	if ($action -eq "Start")
	{
		if ( (Get-WebAppPoolState -Name $poolName).Value -eq "Started")
			{
				Write-Host "AppPool already started $poolName" 
			}
			else
			{
				Write-Host "Starting the AppPool: $poolName" 
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
				Write-Host "AppPool already stopped: $poolName" 
			}
			else
			{
				Write-Host "Shutting down the AppPool: $poolName"
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
    foreach ($path in $args) 
    {
	    if (!(Test-Path $path))
	    {
		    throw [System.Exception] "Application or file does not exist on the specified path: $path"
	    }
    }
}

function DeployLoggingService($buildDir, $assemblyName)
{
    installutil "$buildDir\$assemblyName"
    start-service LoggingWindowsService
}









