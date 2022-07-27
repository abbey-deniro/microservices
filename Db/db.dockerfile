# Choose ubuntu version
FROM mcr.microsoft.com/mssql/server:2019-CU13-ubuntu-20.04

# Create app directory
WORKDIR /usr/src/app

# Copy initialization scripts
COPY . /usr/src/app
            
# Set environment variables, not to have to write them with docker run command
# Note: make sure that your password matches what is in the run-initialization script 
ENV SA_PASSWORD abc123!!@
ENV ACCEPT_EULA Y
ENV MSSQL_PID Express

# Expose port 1433 in case accessing from other container
# Expose port externally from docker-compose.yml
EXPOSE 1435

# Run Microsoft SQl Server and initialization script (at the same time)
CMD /bin/bash ./entrypoint.sh