FROM ubuntu:21.04

EXPOSE 80
EXPOSE 5000
EXPOSE 5001
RUN apt-get update
RUN apt-get install -y wget

RUN wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN rm packages-microsoft-prod.deb
RUN apt-get update
RUN apt-get install -y apt-transport-https
RUN apt-get update
RUN apt-get install -y dotnet-sdk-5.0
RUN apt-get update
RUN apt-get install -y apt-transport-https
RUN apt-get update
RUN apt-get install -y aspnetcore-runtime-5.0
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=http://*:5000

WORKDIR /app/webapi
COPY ["AnimalAPI.csproj", "./"]
RUN dotnet restore "./AnimalAPI.csproj"
COPY . .
RUN dotnet run
ENTRYPOINT ["dotnet", "run"]