FROM debian:stable-slim

EXPOSE 80
EXPOSE 5000
EXPOSE 5001
RUN apt-get update && apt-get install -y wget

# Setup SSH
RUN apt install -y openssh-server && mkdir /var/run/sshd && echo "root:notS0S3cr3tSSHPa55" |chpasswd && sed -ri "s/^#?PermitRootLogin\s+.*/PermitRootLogin yes/" /etc/ssh/sshd_config && sed -ri "s/UsePAM yes/#UsePAM yes/g" /etc/ssh/sshd_config && mkdir /root/.ssh

# Install dev tools
RUN apt install vim nano emacs htop wget git libssl-dev libffi-dev build-essential -y

RUN wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN rm packages-microsoft-prod.deb
RUN apt-get update
RUN apt-get install -y apt-transport-https dotnet-sdk-5.0 aspnetcore-runtime-5.0
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=http://*:5000

WORKDIR /app/webapi
COPY ["AnimalAPI.csproj", "./"]
RUN dotnet restore "./AnimalAPI.csproj"
COPY . .
ENTRYPOINT ["bash", "start.sh"]