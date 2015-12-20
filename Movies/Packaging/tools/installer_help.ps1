param(
	$Destination = "C:\inetpub\wwwroot\CineWeb",
	$AppName = "Default Web Site\CineWeb",	
    $UserName = "developer",
    $Password = "P@ssw0rd",
    $Config = $null
)    
Import-Module WebAdministration  

.(Join-Path (Split-Path $MyInvocation.MyCommand.Path -parent)  ("uninstall_help.ps1")) $AppName 


$destdir = $Destination;
$AppName = $AppName;
$UserAppPool = $UserName;
$PasswordAppPool = $Password;

$installDir         = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$installDir         = "$(Split-Path -parent $installDir)"
$InternalPackageDir = $installDir + "\app\*"


write-host "Installing Site"
$pool = New-WebAppPool -Name $PoolName -force
$pool.managedRuntimeVersion = "v4.0"
$pool.processModel.identityType = 3 #SpecificUser -- http://msdn.microsoft.com/en-us/library/microsoft.web.administration.processmodelidentitytype%28v=vs.90%29.aspx
$pool.processModel.userName = $UserAppPool
$pool.processModel.password = $PasswordAppPool
$pool | Set-Item 
	
if (-not (test-path $destdir) ) {
	mkdir $destdir
}	


##Copy Package Content to Destination
Copy-Item $InternalPackageDir -Destination $destdir -Recurse -force

if (-not [string]::IsNullOrWhiteSpace($Config))
{
    Write-Host "Apply configuration " $Config

    $InternalConfig = Join-Path (join-path $installDir "\tools\config\") $Config
    $DestinationConfig = Join-Path $destdir "Web.Config"
    Copy-Item $InternalConfig  -Destination  $DestinationConfig -Recurse -Force
}

$site = New-WebApplication -Name (split-path $AppName -leaf) -Site (split-path $AppName) -PhysicalPath $Destination -ApplicationPool $PoolName -Force

$tsite = (split-path $AppName)
$tapp = (split-path $AppName -leaf)

Set-WebConfiguration "/system.applicationHost/sites/site[@name='$tsite' and @id='1']/application[@path='/$tapp']/VirtualDirectory[@path='/']" -Value @{userName=$UserAppPool;password=$PasswordAppPool}

$pool.Start()

Write-Host "web site installed"