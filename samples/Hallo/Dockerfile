FROM microsoft/dotnet:2.0.0-sdk-jessie AS builder

WORKDIR /app
COPY src /app
RUN dotnet restore Hallo.csproj
RUN dotnet publish --configuration Release --output ./out


FROM microsoft/dotnet:2.0-runtime-jessie
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-09-23

RUN curl -SL https://github.com/alexellis/faas/releases/download/0.6.5/fwatchdog > /usr/bin/fwatchdog \
    && chmod +x /usr/bin/fwatchdog

WORKDIR /app/
COPY --from=builder /app/out/* ./

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

ENV fprocess="dotnet /app/Hallo.dll"
EXPOSE 8080

CMD ["fwatchdog"]