Docker-compose does not start up the server properly.

Manual startup works:
    #1: Build and Start the server
    /AnimalShelter-Server/AnimalAPI
    docker build -t ctfserver .
    docker run -it --rm -p 5000:5000 --name ctfserver ctfserver

    #2 Build and start the client
    /AnimalShelter-Client 
    docker build -t ctfclient .
    Docker run --rm -p 8080:8080 --name ctfclient ctfclient
