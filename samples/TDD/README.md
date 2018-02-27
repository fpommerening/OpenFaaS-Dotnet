# Test Driven Development with OpenFaaS

TDD (Test Driven Development) ist ein sehr gutes Paradigma für die Entwicklung von Functions. Functions enthalten kaum Infrastruktur-Code und konzentieren sich auf die eigentliche Business-Logic.
Deren Funktion lässt sich mittels Unittests sehr gut testen.

## Templates
Das folgende Beispiel nutzt spezielle OpenFaaS-CLI Vorlagen. Diese werden aus einen git-Repository geladen.

    c:\OpenFaaS\faas-cli.exe template pull https://github.com/fpommerening/openfaas-template-csharp.git

## Function erstellen

    c:\OpenFaaS\faas-cli.exe new tdd --lang csharp-tdd

## Visual Studio Solution
Mit dem Befehl dotnet-CLI fehlt wird die Projektmappe erstellt. Wird kein Name definiert - wird automatisch der Ordner-Name verwendet.

    dotnet new sln

    dotnet sln add ./tdd/Function.csproj

## Testprojekt

    dotnet new mstest -lang c# --name tests

    dotnet sln add ./tests/tests.csproj

    dotnet add ./tests/tests.csproj reference ./tdd/Function.csproj

    dotnet add ./tests/tests.csproj package OpenFaaS.DotNet

    dotnet add ./tests/tests.csproj package FluentAssertions

