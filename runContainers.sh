#!/bin/bash
echo -e "-=== Removing old containers ===-\n"
docker stop defensive_ctf_shelterapi_running && docker rm defensive_ctf_shelterapi_running
docker stop defensive_ctf_shelterclient_running && docker rm defensive_ctf_shelterclient_running
docker stop defensive_ctf_attval_running && docker rm defensive_ctf_attval_running

echo -e "\n-=== Running new containers ===-\n"

# API
apiID=$(docker run -d --name defensive_ctf_shelterapi_running defensive_ctf_shelterapi_build)
apiIP=$(docker inspect --format='{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' defensive_ctf_shelterapi_running)
echo -e "Vuln API can be found on http://$apiIP:5000\nDocker ID is $apiID\n"

# Client
clientID=$(docker run -d --name defensive_ctf_shelterclient_running defensive_ctf_shelterclient_build)
clientIP=$(docker inspect --format='{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' defensive_ctf_shelterclient_running)
echo -e "Vuln client can be found on http://$clientIP:8080\nDocker ID is $clientID\n"

# Attacker/Validator machine
attvalID=$(docker run -d --name defensive_ctf_attval_running defensive_ctf_attval_build)
attvalIP=$(docker inspect --format='{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' defensive_ctf_attval_running)
echo -e "Validator machine can be found on http://$attvalIP\nDocker ID is $attvalID\n"