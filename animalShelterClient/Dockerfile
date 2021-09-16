FROM debian:stable-slim

# install simple http server for serving static content
RUN apt update && apt install nodejs npm -y
RUN npm install -g http-server

# Setup SSH
RUN apt install -y openssh-server && mkdir /var/run/sshd && echo "root:notS0S3cr3tSSHPa55" | chpasswd && sed -ri "s/^#?PermitRootLogin\s+.*/PermitRootLogin yes/" /etc/ssh/sshd_config && sed -ri "s/UsePAM yes/#UsePAM yes/g" /etc/ssh/sshd_config && mkdir /root/.ssh

# Install dev tools
RUN apt install vim nano emacs htop wget git libssl-dev libffi-dev build-essential -y

# make the 'app' folder the current working directory
WORKDIR /app

# copy both 'package.json' and 'package-lock.json' (if available)
COPY package*.json ./

# install project dependencies
RUN npm install && npm i --save bootstrap jquery && npm i --save popper.js && npm i --save @fortawesome/fontawesome-svg-core && npm i --save @fortawesome/free-solid-svg-icons && npm i --save @fortawesome/vue-fontawesome

# copy project files and folders to the current working directory (i.e. 'app' folder)
COPY . .

# build app for production with minification
RUN npm run build

EXPOSE 8080
CMD [ "bash", "start.sh" ]