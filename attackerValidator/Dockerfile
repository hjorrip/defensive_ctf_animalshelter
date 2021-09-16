# Use latest version of stable debian, and set working folder in the container
FROM debian:stable-slim
WORKDIR /opt/attackerValidator

# Install needed packages
RUN apt update && apt install python3 python3-pip -y

# Move files and install python dependencies
COPY . .
RUN pip3 install -r requirements.txt

# Expose the used port
EXPOSE 80

# Start the service
ENTRYPOINT ["bash"]
CMD ["start.sh"]