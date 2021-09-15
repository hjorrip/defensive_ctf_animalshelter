#!/bin/bash
cd animalShelterAPI && docker build -t defensive_ctf_shelterapi_build . && cd ..
cd animalShelterClient && docker build -t defensive_ctf_shelterclient_build . && cd ..