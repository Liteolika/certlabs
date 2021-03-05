# ACR Role-based Auth
# https://docs.microsoft.com/en-us/azure/container-registry/container-registry-roles

# Owner, Contributor, Reader
# AcrPush = Push and pull image
# AcrPull = Pull image
# AcrDelete = Delete image data
# AcrImageSigner = Sign images

# When automating in CI/CD it needs docker AcrPush

$RG_NAME = "container-demo";

# az group create --name $RG_NAME --location "westeurope"

# Azure Container Registry name. 
# Needs to be globally unique in Azure
# Will create fqdn: psacrdemo.azurecr.io
$ACR_NAME = "psacrdemo"; 

# az acr create `
#     --resource-group $RG_NAME `
#     --name $ACR_NAME `
#     --sku Standard

# Login to the ACR with the current Azure cli credentials
# az acr login --name $ACR_NAME

# Get the fqdn of the ACR
$LOGIN_SERVER = $(az acr show --name $ACR_NAME --query loginServer --output tsv)

# Add an alias to our local container image 
# Tells where we send the image on docker push
# docker tag [local] [target]
docker tag webappimage:v1 $LOGIN_SERVER/webappimage:v1

docker push $LOGIN_SERVER/webappimage:v1

# List images
az acr repository list --name $ACR_NAME --output table
az acr repository show-tags --name $ACR_NAME --respository webappimage --output table

# Build using ACR tasks
az acr build --image "webappimage:v1-acr-task" --registry $ACR_NAME .
