FROM microsoft/dotnet:2.0-sdk-jessie AS builder

WORKDIR /app
COPY src /app
RUN dotnet restore Configs.csproj
RUN dotnet publish --configuration Release --output ./out


FROM microsoft/aspnetcore:2.0-jessie
LABEL maintainer "frank@pommerening-online.de"
ENV ASPNETCORE_URLS http://0.0.0.0:5000
EXPOSE 5000
WORKDIR /app/

COPY --from=builder /app/out/* ./

ENV REFRESHED_AT 2018-01-28

ENTRYPOINT ["dotnet", "Configs.dll"]