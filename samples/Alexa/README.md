# Alexa-Beispiel

In diesem Beispiel wird ein Backend für einen Amazon Alexa Skill mit OpenFaaS gezeigt.

Voraussetzung:
* Docker-Host im Internet
* Internet-Domäne (de, com, org ...)
* Amazon-Entwickler-Zugang [Anlegen](https://developer.amazon.com/de/)

## Anlegen SSL-Proxy
Das Backend für einen Amazon Alexa Skill muss per https aufrufen werden. OpenFaaS unterstützt dies nicht direkt.
Den Protokollwechsel von https zu http übernimmt ein nginx - container. Das SSL-Zertifikat wird dabei von der Initative [Let's Encrypt](https://letsencrypt.org/) bereitgestellt. Die notwendigen Images werden von Jason Wilder [GitHub](https://github.com/jwilder/nginx-proxy) / [DockerHub](https://hub.docker.com/r/jwilder/nginx-proxy/) sowie Yves Blusseau [GitHub](https://github.com/JrCs/docker-letsencrypt-nginx-proxy-companion) / [Dockerhub](https://hub.docker.com/r/jrcs/letsencrypt-nginx-proxy-companion/) bereitgestellt.

Das Compose-File für Docker-Stack liegt im Ordner SSL-Proxy.
### Vorbereitung
Anlegen Volumes:
- 