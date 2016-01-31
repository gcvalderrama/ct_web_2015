 $arguments = @{}

  $packageParameters = $env:chocolateyPackageParameters

  # Default the values
    [string]$Destination = "C:\inetpub\wwwroot"
    [string]$AppName = "DefaultSite"    
    [string]$UserName = "Administrator"
    [string]$Password = "password"  

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
      

      if ($arguments.ContainsKey("AppName")) {          
          $AppName = $arguments["AppName"]
      }

  } else {
      Write-Debug "No Package Parameters Passed in"
  }
    
write-host 'Uninstall web application  operation'
write-host 'AppName' $AppName

.(Join-Path (Split-Path $MyInvocation.MyCommand.Path -parent)  ("uninstall_help.ps1")) $AppName 