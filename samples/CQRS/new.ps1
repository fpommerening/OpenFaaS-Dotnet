param([string]$ProjectName='')

$cli_path = "C:\OpenFaaS\faas-cli.exe"

if(Test-Path *.yml)
{
    & $cli_path 'new' $ProjectName --lang csharp-common --append ((Get-Childitem *.yml).Name)
}
else
{
    & $cli_path 'new' $ProjectName --lang csharp-common -f stack.yml
}

if(-not(Test-Path *.sln))
{
    & dotnet new sln 
}

& dotnet new classlib -n $ProjectName -lang 'c#'
& dotnet sln add ./$ProjectName/$ProjectName.csproj
Remove-Item ./$ProjectName/Class1.cs


