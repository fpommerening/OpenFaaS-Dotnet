
$cli_path = "C:\OpenFaaS\faas-cli.exe"

& docker build -t csharp-common -f ./template/csharp-common/Common.Dockerfile .

$stack_file = "stack.yml"

if(Test-Path *.yml)
{
    $stack_file = (Get-Childitem *.yml).Name
}
& $cli_path build -f $stack_file
