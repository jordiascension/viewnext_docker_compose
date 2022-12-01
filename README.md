https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-7.0

https://www.yogihosting.com/docker-compose-aspnet-core/

En esta carpeta encontramos el fichero config de git: gitconfig
C:\Program Files\Git\etc

-Asegurarse que el parámetro autocrlf=input
si lo tenemos a true (por defecto en windows) cuando hagamos un clone en el repositorio nos modificará los ficheros
de lf a ctrlf
[core]
	autocrlf = input

Sinó otra opción es no hacer un clone del repositorio y bajárselo como un zip