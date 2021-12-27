# Logitech Game Monitor Local Concourse Setup


---
## Install Windows Docker for Desktop

https://docs.docker.com/desktop/windows/install/

---

## Create local Concourse instance
```
curl.exe -O https://concourse-ci.org/docker-compose.yml
docker-compose up -d
```

## Create local Concourse Fly.exe folder
```
$concoursePath = 'C:\concourse\'; mkdir $concoursePath; `
[Environment]::SetEnvironmentVariable('PATH', "$ENV:PATH;${concoursePath}", 'USER'); `
$concourseURL = 'http://localhost:8080/api/v1/cli?arch=amd64&platform=windows'; `
Invoke-WebRequest $concourseURL -OutFile "${concoursePath}\fly.exe"
```

---
## Set Target

```
c:\concourse\fly.exe -t local-concourse login -c http://localhost:8080 -u test -p test
```

## Set/Update Pipeline

```
cd ci
c:\concourse\fly.exe -t local-concourse set-pipeline -p game-monitor -c concourse-pipeline.yml -l properties.yml
```

## UnPause the Pipeline

```
c:\concourse\fly.exe -t local-concourse unpause-pipeline -p game-monitor
```

## Manual Trigger the Pipeline
```
c:\concourse\fly.exe -t local-concourse trigger-job --job game-monitor/game-monitor-job --watch
```

