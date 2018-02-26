
$cli_path = "C:\OpenFaaS\faas-cli.exe"

& docker build -t 'csharp-common' './template/csharp-common/Common.Dockerfile' '.'

$stack_file = "stack.yml"

# $stack_file erste Datei *.yml
& $cli_path build -f $stack_file
