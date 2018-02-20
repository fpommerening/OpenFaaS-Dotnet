param([string]$ProjectName='')

$cli_path = "C:\OpenFaaS\faas-cli.exe"

& $cli_path  'new' $ProjectName --lang csharp-common --append stack.yml

# if not exists
& dotnet new sln 

& dotnet new classlib -n $ProjectName -lang csharp
& dotnet sln add ./$ProjectName/$ProjectName.csproj
& Remove-Item ./$ProjectName/Class1.cs


