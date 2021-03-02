$rg = "psdemo-rg"
$name = "psdemo-cli"

# Azure CLI
az group create --name $rg --location "westeurope"

az vm create `
    --resource-group $rg `
    --name "$($name)_win" `
    --image "win2019datacenter" `
    --admin-username "demoadmin" `
    --admin-password "wo.rd*pas@s123"

az vm open-port `
    --resource-group $rg `
    --name "$($name)_win" `
    --port "3389"

az vm list-ip-addresses `
    --resource-group $rg `
    --name "$($name)_win" `
    --output table

az vm create `
    --resource-group $rg `
    --name "$($name)_nix" `
    --image "UbuntuLTS" `
    --admin-username "demoadmin" `
    --authentication-type "ssh" `
    --ssh-key-value C:\Users\peter\ssh_public.pub

az vm open-port `
    --resource-group $rg `
    --name "$($name)_nix" `
    --port "22"

az vm list-ip-addresses `
    --resource-group $rg `
    --name "$($name)_nix" `
    --output table