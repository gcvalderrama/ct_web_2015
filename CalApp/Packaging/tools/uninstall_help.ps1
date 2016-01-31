param(	
	$AppName = "Default Web Site\CineWeb"	    
)    

Import-Module WebAdministration  

Write-Host "Uninstall web application"
Write-Host "=============================================="


$installDir         = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$installDir         = "$(Split-Path -parent $installDir)"
$InternalPackageDir = $installDir + "\app\*"

$PoolName = (split-path $appName -leaf) + "AppPool"

$site = (Get-Item ("IIS:\Sites\" + $AppName) -ErrorAction SilentlyContinue)
$pool = $null

if (-Not ($site -eq $null) -and -not($site.ApplicationPool -eq $null))
{
    $destdir = $site.PhysicalPath;
	$pool = Get-Item ("IIS:\AppPools\" + $site.ApplicationPool) -EA 0    
	if (-Not ($pool.state -ieq "stopped"))
	{
		$tryCount = 1
		$maxTryCount = 10
		$continueTrying = $false
		$waitTimeInSeconds = 1
		Do
		{
			try{
				$pool.Stop()            
			}
			Catch
			{
				if ($tryCount -lt $maxTryCount)
				{
					$tryCount = $tryCount + 1
					$continueTrying = $true
					Start-Sleep -s $waitTimeInSeconds
				}else
				{
					$continueTrying = $false
					throw
				}
			}
		}while($continueTrying)  
				
		while(-not ($pool.state -ieq "stopped"))
		{
			Start-Sleep -s $waitTimeInSeconds
			$count = $count + 1
			if ($count -eq 10) {break}
		}
	}

	$tempFolder = join-path (join-path ($env:windir) ("Microsoft.NET\Framework64\v4.0.30319\Temporary ASP.NET Files")) $site.Name
	if (test-path $tempFolder -pathType container)
	{
		Get-Item $tempFolder | Remove-Item -Recurse -Force -ErrorAction SilentlyContinue 
		Write-Host $("ASP .Net Temporary Files for web application `"{0}`"  deleted" -f $site.Name)
	}    
	write-host "Remove Site"    
	Remove-WebApplication -Name (split-path $AppName -leaf) -Site (split-path $AppName)    

    if (-not((Get-Item ("IIS:\AppPools\" + $PoolName) -EA 0) -eq $null))
    {
	    write-host "Remove Pool" $PoolName
	    Remove-WebAppPool $PoolName
    } 

    if (test-path $destdir) {
        write-host "Clean directory " $destdir

	    $tmp_destdir =  $destdir + '/*'
        Remove-Item -recurse -force $tmp_destdir
    }	
}
	
Write-Host "=============================================="