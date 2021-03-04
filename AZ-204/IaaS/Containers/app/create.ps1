

dotnet build ./webapp
dotnet run --project ./webapp
#curl https://localhost:5001

dotnet publish -c Release ./webapp
docker build --progress plain -t webappimage:v1 .

# Clean up image cache
#docker rmi webappimage:v1 && docker builder prune --force && docker image prune --force

# run the container locally
docker run --name webapp --publish 8080:80 --detach webappimage:v1
#publish = route from:to
#detach = give back the console

docker stop webapp
docker rm webapp