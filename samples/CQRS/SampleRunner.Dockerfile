FROM microsoft/dotnet:2.0-sdk AS builder

WORKDIR /app/SampleRunner
COPY AddConference /app/AddConference
COPY Data /app/Data
COPY SampleRunner /app/SampleRunner
COPY Data /app/Data
RUN dotnet restore SampleRunner.csproj
RUN dotnet publish --configuration Release --output ./out


FROM microsoft/dotnet:2.0-runtime
LABEL maintainer "frank@pommerening-online.de"

EXPOSE 8080

WORKDIR /app/
RUN echo "Pulling watchdog binary from Github." \
    && curl -sSL https://github.com/openfaas/faas/releases/download/0.6.9/fwatchdog > /usr/bin/fwatchdog \
    && chmod +x /usr/bin/fwatchdog

ENV REFRESHED_AT 2018-02-06

COPY --from=builder /app/SampleRunner/out/* ./

ENV fprocess="dotnet ./SampleRunner.dll"

CMD ["fwatchdog"]