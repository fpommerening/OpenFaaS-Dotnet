param([string]$ProjectName='')

$cli_path = "C:\OpenFaaS\faas-cli.exe"

if(-not(Test-Path *.yml))
{
    & $cli_path 'new' $ProjectName --lang csharp -f stack.yml
}
else
{
    & $cli_path 'new' $ProjectName --lang csharp --append stack.yml    
}

if(-not(Test-Path *.sln))
{
    & dotnet new sln 
}

& dotnet new classlib -n $ProjectName -lang 'c#'
& dotnet sln add ./$ProjectName/$ProjectName.csproj
Remove-Item ./$ProjectName/Class1.cs


