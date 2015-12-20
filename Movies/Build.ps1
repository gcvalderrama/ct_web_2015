param(
    [string]$version="1.0.0",
    [string]$AppName    
)


####
#### Function to generate all available xml/config transformations and put them all on the package output directory
####
function TransFormXmlConfigFiles([string]$projectFilePath,[string]$configDestinationFolder)
{
    #Read project file xml
    [xml]$xmlProjectContent = (Get-Content $projectFilePath)	
    
    #logic to check if the project is a web application
    $projectTypeGuids = $xmlProjectContent.Project.PropertyGroup.ProjectTypeGuids
    $IsWap = $false
    $IsExe = $false
    $assemblyName = $null

    $assemblyName = $xmlProjectContent.Project.PropertyGroup[0].AssemblyName

    $IsExe = $xmlProjectContent.Project.PropertyGroup.OutputType[0].ToLower().EndsWith("exe")    

    #if its not an exe, then check if its a web
    if (!$IsExe)
    {
        if ($projectTypeGuids.GetType().Name -eq "Object[]")
        {
            if ($projectTypeGuids.Count -gt 0)
            {
                $projectTypeGuids = $projectTypeGuids[0]
            }
            else
            {  
                $projectTypeGuids = $null
            }
        }

        if ($projectTypeGuids)
        {
            $IsWap = $projectTypeGuids.ToLower().Contains("349c5851-65df-11da-9384-00065b846f21".ToLower())
        }            
    }    

    $projectFolderPath = (Split-Path -Parent $projectFilePath) + "\" # Script Directory

    Add-Type -Path "C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v12.0\Web\Microsoft.Web.XmlTransform.dll"
        

    #get all the files that are marked as transformations
    $transformationFilesNodes = $xmlProjectContent.Project.ItemGroup.None | %{ if ($_.DependentUpon -ne $null) {$_} }
      

    foreach($transformationNode in $transformationFilesNodes)
    {
        $xdt = join-path $projectFolderPath $transformationNode.Include

        $xdtRelativeFolder = (Split-Path -Parent $transformationNode.Include)

        #calculate source and destination files based on the relative position and name of the transformation file
        $src = join-path $projectFolderPath ($xdtRelativeFolder + "\" + $transformationNode.DependentUpon)
        $dst = join-path $configDestinationFolder $transformationNode.Include           

        #create the FOLDER in the package building location
        $configDestinationFolderForSpecificTransformation = join-path $configDestinationFolder $xdtRelativeFolder

        #if they are not web applications and they are app.config located in the root
        #the config name should be changed to use the assembly name
        if (!$IsWap -and !$xdtRelativeFolder -and ($transformationNode.DependentUpon.ToLower() -eq "app.config"))
        {
            $extension = 'dll'
            if ($IsExe) 
            {
                $extension =  'exe'
            }
            $diferentiator = (Split-Path -leaf $transformationNode.Include).split('.')[1]
            $dst = join-path $configDestinationFolder ($xdtRelativeFolder + "\" + ($assemblyName + "." + $extension + "." + $diferentiator + ".config"))                 
        }        

        if (-not (test-path $configDestinationFolderForSpecificTransformation) ) {
		    mkdir $configDestinationFolderForSpecificTransformation
	    }

        
            $doc = New-Object Microsoft.Web.XmlTransform.XmlTransformableDocument
            $doc.PreserveWhiteSpace = $true
            
            $doc.Load($src)

            $trn = New-Object Microsoft.Web.XmlTransform.XmlTransformation($xdt)

            #perform transformatio and save it on the package building location
            if ($trn.Apply($doc))
            {
                $doc.Save($dst)
                Write-Output "Output file: $dst"
            }
            else
            {
                throw "Transformation terminated with status False"
            }
        
    }
}

$msbuild = "C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe"

$current =  "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"

$projectFilePath = join-path $current "\MoviesSite\MoviesSite.csproj"
$package_config_path = join-path $current "\Build\tools\config"

if ( -not ( Test-Path ".\Build") )
{
    mkdir ".\Build"
}


Remove-Item .\Build\* -recurse -Force

& $msbuild $projectFilePath /t:Build /p:Configuration=Release /p:DeployOnBuild=True /p:PublishProfile=Release


mkdir .\Build\tools\

mkdir $package_config_path

TransFormXmlConfigFiles $projectFilePath  $package_config_path

Copy-Item Movie.nuspec -Destination .\Build\app.nuspec

Copy-Item .\Packaging\tools\* -Destination .\Build\tools\ -Recurse

$nuget_path = Join-Path $current ".\Build\app.nuspec"

$xml = [xml](Get-Content $nuget_path)
$xml.SelectNodes("//version") | % { 
        $_."#text" = $_."#text".Replace("version", $version) 
}

$xml.Save($nuget_path)


cd ".\Build"

& choco pack app.nuspec --version=$version

cd $current