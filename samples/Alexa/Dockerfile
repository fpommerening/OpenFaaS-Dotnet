FROM microsoft/dotnet:2.0.0-sdk-jessie AS builder

WORKDIR /app
COPY src /app
RUN dotnet restore Alexa.csproj
RUN dotnet publish --configuration Release --output ./out


FROM microsoft/aspnetcore:2.0-jessie
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-10-06

WORKDIR /app/
COPY --from=builder /app/out/* ./

ENV ASPNETCORE_URLS http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Alexa.dll"]