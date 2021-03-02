$rg = "psdemo-rg1"
$name = "psdemo"

New-AzResourceGroup -Name $rg -Location "westeurope"

$username = "demoadmin"
$password = ConvertTo-SecureString "wo.rd*pas@s123" -AsPlainText -Force
$cred = New-Object System.Management.Automation.PSCredential ($username, $password)

New-AzVM `
    -ResourceGroupName $rg `
    -Name "$($name)win" `
    -Image "Win2019Datacenter" `
    -Credential $cred `
    -OpenPorts 3389

Get-AzPublicIpAddress `
    -ResourceGroupName $rg `
    -Name "$($name)win" `
    | Select-Object IpAddress

# Remove-AzResourceGroup -Name $rg