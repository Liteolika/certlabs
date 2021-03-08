# Base container image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

# Command - Create app directory
RUN mkdir app

# Set the current working directory
WORKDIR /app

# Do some copying of files into the container
COPY ./webapp/bin/Release/netcoreapp3.1/publish ./
#COPY ./config.sh ./

# Execute script inside container
#RUN bash ./config.sh

# Set port to listen on for application
EXPOSE 80

# The command to start the app
ENTRYPOINT [ "dotnet", "webapp.dll" ]

# Execute docker build with: docker build -t webappimage:v1
# -t = Tag image with name and version
