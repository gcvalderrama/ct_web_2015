  $arguments = @{}

  $packageParameters = $env:chocolateyPackageParameters

  # Default the values
    [string]$Destination = "C:\inetpub\wwwroot"
    [string]$AppName = "DefaultSite"    
    [string]$UserName = "Administrator"
    [string]$Password = "password"  
    [string]$Config = "configuration"

  # Now parse the packageParameters using good old regular expression
  if ($packageParameters) {
      $match_pattern = "\/(?<option>([a-zA-Z]+)):(?<value>([`"'])?([a-zA-Z0-9- _\\:\.\@]+)([`"'])?)|\/(?<option>([a-zA-Z]+))"
      $option_name = 'option'
      $value_name = 'value'

      if ($packageParameters -match $match_pattern ){
          $results = $packageParameters | Select-String $match_pattern -AllMatches
          $results.matches | % {
            $arguments.Add(
                $_.Groups[$option_name].Value.Trim(),
                $_.Groups[$value_name].Value.Trim())
        }
      }
      else
      {
          Throw "Package Parameters were found but were invalid (REGEX Failure)"
      }

      if ($arguments.ContainsKey("Destination")) {          
          $Destination = $arguments["Destination"]
      }

      if ($arguments.ContainsKey("AppName")) {          
          $AppName = $arguments["AppName"]
      }

      if ($arguments.ContainsKey("UserName")) {          
          $UserName = $arguments["UserName"]
      }      
      if ($arguments.ContainsKey("Password")) {          
          $Password = $arguments["Password"]
      }      
      if ($arguments.ContainsKey("Config")) {          
          $Config = $arguments["Config"]
      }      
  } else {
      Write-Debug "No Package Parameters Passed in"
  }
    

Write-Host "Web Installation Parameters"
Write-Host "=========================="
write-host 'Destination' $Destination
write-host 'AppName' $AppName
write-host 'Username' $UserName
write-host 'Password' $Password
Write-Host 'Config'  $Config
Write-Host "=========================="

.(Join-Path (Split-Path $MyInvocation.MyCommand.Path -parent)  ("installer_help.ps1")) $Destination $AppName $UserName $Password $Config