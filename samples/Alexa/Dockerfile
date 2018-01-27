FROM microsoft/dotnet:2.0-sdk-jessie AS builder

WORKDIR /app
COPY src /app
RUN dotnet restore Alexa.csproj
RUN dotnet publish --configuration Release --output ./out


FROM microsoft/dotnet:2.0-runtime-jessie
LABEL maintainer "frank@pommerening-online.de"

WORKDIR /app/
ENV REFRESHED_AT 2017-10-06

COPY --from=builder /app/out/* ./

ENTRYPOINT ["dotnet", "Alexa.dll"]