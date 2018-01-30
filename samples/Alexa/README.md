# Alexa-Beispiel

In diesem Beispiel wird ein Backend für einen Amazon Alexa Skill mit OpenFaaS gezeigt.

Voraussetzung:
* Docker-Host im Internet
* Internet-Domäne (de, com, org ...)
* Amazon Entwickler-Zugang [Anlegen](https://developer.amazon.com/de/)

## Anlegen SSL-Proxy
Das Backend für einen Amazon Alexa Skill muss per https aufrufen werden. OpenFaaS unterstützt dies nicht direkt.
Den Protokollwechsel von https zu http übernimmt ein nginx - container. Das SSL-Zertifikat wird dabei von der Initative [Let's Encrypt](https://letsencrypt.org/) bereitgestellt. Die notwendigen Images werden von Jason Wilder [GitHub](https://github.com/jwilder/nginx-proxy) / [DockerHub](https://hub.docker.com/r/jwilder/nginx-proxy/) sowie Yves Blusseau [GitHub](https://github.com/JrCs/docker-letsencrypt-nginx-proxy-companion) / [Dockerhub](https://hub.docker.com/r/jrcs/letsencrypt-nginx-proxy-companion/) bereitgestellt.

Das Compose-File für Docker-Stack liegt im Ordner SSL-Proxy. Wichtig es werden 3 Volumes (ssl-html, ssl-vhosts und ssl-certs) sowie eine Netzwerk (functions) benötigt.

#### Anlegen Volume
```docker
docker volume create  --drive local NAME 
```
#### Anlegen Netzwerk
```docker
docker network create --drive overlay NAME 
```
#### Stack Deployment bereitstellen
```docker
docker stack deploy -c docker-compose.yml NAME 
```

## Functions-Image erstellen
Die Konfiguration aus diesem Repo zeigt für die Funktion auf ein Image aus meinem Docker-Hub Account. Ihr könnt natürlich auch ein eigenes Image verwenden welches ihr im Docker-Hub bzw. lokal auf dem Host ablegt. Sollte eure Docker-Umgebung aus mehr als einem Swarm-Knoten bestehen, ist die Verwendung einer Registry z.B. Docker-Hub zu empfehlen.
Zur Änderung des Image bitte die Zeile 131 des Compose-File ändern.

## OpenFaaS Gateway starten
In diesem Ordner liegt das Compose-File für den Start des OpenFaaS Gateway. Bitte die Umgebungsvariablen in Zeile 18 - 20 mit eigene Informationen ändern. Diese werden vom SSL-Proxy abgefragt und zur Anmeldung des Let's Encrypt Zertifikats genutzt. 
Bei der Bereitstellung per Docker Stack sollte für das Beispiel "faas" als Name verwendet werden.
```docker
LETSENCRYPT_EMAIL: "postfach@deine-domäne"
LETSENCRYPT_HOST: "subdomäne.deine-domäne"
VIRTUAL_HOST: "subdomäne.deine-domäne"
```

## Amazon Entwicker-Zugang
Beim Anlegen des Entwickler-Zugangs sollte ihr darauf achten, euer normales Amazon-Konto zu verwenden. Nur so könnt ihr euren Skill mit euren vorhanden Amazon Echo Geräten testen ohne den Skill zu veröffentlichen.

## Skill anlegen
Für die Erstellung bzw. Änderung eines Amazon Alexa-Skill meldet euch auf [Entwicker-Portal](https://developer.amazon.com/de/) an.
1) Im oberen Teil öffnet ihr die Developer-Konsole.
![Start Developer Konsole](https://github.com/fpommerening/openfaas-dotnet/blob/master/samples/Alexa/images/AlexaSample_01.png "Start Developer Konsole")
2) Unter Alexa - das Alexa Skill Kit öffnen
![Start Alexa Skill Kit](https://github.com/fpommerening/openfaas-dotnet/blob/master/samples/Alexa/images/AlexaSample_03.png "Alexa Skill Kit")
3) Zum anlegen "Add a New Skill" oder zum bearbeiten bestehenden Skill aus der Liste wählen
![Skill öffnen](https://github.com/fpommerening/openfaas-dotnet/blob/master/samples/Alexa/images/AlexaSample_04.png "Skill öffnen")
4) Skill Informationen
Wichtig: die Sprache kann nicht geändert werden!
Für das Beispiel heißt der Skill "Meetup-Skill" und verwendet als Schlüsselwort (Invocation Name) "Meetup". 
![Skill öffnen](https://github.com/fpommerening/openfaas-dotnet/blob/master/samples/Alexa/images/AlexaSample_05.png "Skill öffnen")
5) Intent-Schema
Über das Interaction Model bzw. Intent-Schema wird gesteuert welche Befehle (intent) verfügbar sind.
Dazu im Feld "Intent Schema" die entsprechende json-Datei pflegen.
```json
{
  "intents": [
    {
      "intent": "greeting"
    },
    {
      "intent": "breaknow"
    },
    {
      "intent": "sendoff"
    },
    {
      "intent": "AMAZON.HelpIntent"
    },
    {
      "intent": "AMAZON.StopIntent"
    }
  ]
}
```
Die Zuordnung der Äußerungen zum Befehl erfolgt im Feld "Sample Utterances". Im folgenden Beispiel wird u.a. dem Befehl "greeting" die Äußerungen "Sag Hallo" sowie "Beginne Treffen" zugeordnet.
```
greeting sag hallo
greeting beginne treffen
breaknow pause
sendoff sag auf wiedersehen
sendoff beende treffen
sendoff schluss jetzt
```
6) Configuration
Die Verknüpfung zu eurem OpenFaaS Gateway wird im Punkt "Configuration" definiert.
Dazu bitte auf https ändern und eure URL (subdomäne.deine-domäne/) mit dem Zusatz "function/faas_alexa" eintragen.
Hinweis: sollte bei der Bereitstellung ein abweichende Name als "faas" verwendet wurde sein, muss der Zusatz angepasst werden.
![Configuration](https://github.com/fpommerening/openfaas-dotnet/blob/master/samples/Alexa/images/AlexaSample_06.png "Configuration")

7) SSL-Certifikat
Für das SSL-Certifikat sollte die Einstellung auf der Option "My development endpoint has a certificate from a trusted certificate authority" verbleiben
![SSL-Certifikat](https://github.com/fpommerening/openfaas-dotnet/blob/master/samples/Alexa/images/AlexaSample_07.png "Certifikat")

8) Test
Die Einrichtung ist nun abgeschlossen. Für den Bereich Test könnt ihr den Skill probieren. Dazu im Feld Text innerhalb des "Service Simulator" - Bereichs eine Äußerung z.B. "Sag hallo" eingeben und mit "ASK..." absenden.
![SSL-Certifikat](https://github.com/fpommerening/openfaas-dotnet/blob/master/samples/Alexa/images/AlexaSample_08.png "Certifikat")
Alternativ könnt ihr auch einen Echo ansprechen z.B. "Alexa starte Meetup und sag hallo".
