# Logitech Game Monitor Local Artifactory Setup


---

## Create local Artifactory instance
```
docker volume create artifactory-data
docker pull releases-docker.jfrog.io/jfrog/artifactory-oss:latest
docker run -d --name artifactory -p 8082:8082 -p 8081:8081 -v artifactory-data:/var/opt/jfrog/artifactory releases-docker.jfrog.io/jfrog/artifactory-oss:latest
```
* Default Username/Password =  admin/password