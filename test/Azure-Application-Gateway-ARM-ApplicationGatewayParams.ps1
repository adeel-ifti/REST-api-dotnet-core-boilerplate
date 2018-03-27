#
#  This PowerShell script shows how to create a sample traffic manager profile from the accompanying template.
#  As DNS names need to be unique, please edit azuredeploy.parameters.json and replace the values marked with '#####'
#

# parameters 

Param(
   [string]$rgName = "wes-test-sandpit-appgateway-uks1",
    [string]$location = "UK South"
   
  
)


# $parameters = @{

#   "azureWebApp1" = "dare-test-sitecore-v2-189690-cm.azurewebsites.net";
#   "azureWebApp2" = "dare-test-sitecore-615907-single.azurewebsites.net"
# }

# import the AzureRM modules

  Import-Module AzureRM.Resources

#  login
# Login-AzureRmAccount

# create the resource from the template - pass names as parameters
#   $scriptDir = Split-Path $MyInvocation.MyCommand.Path
  
#   New-AzureRmResourceGroup -Location $location -Name $rgName
#   New-AzureRmResourceGroupDeployment -Verbose -Force -ResourceGroupName $rgName -TemplateFile "$scriptDir\azuredeploy.json" -TemplateParameterFile "$scriptDir\azuredeploy.parameters.json" -TemplateParameterObject $parameters

#  display the end result

Write-Host ****************** Fetching app gateway **********************

$appGW = Get-AzureRmPublicIpAddress -ResourceGroupName $rgName.Trim()
$appGW.Name.Trim()
$appGW.Id.Trim()

Write-Host ****************** Settings params **********************

Write-Host  "$("##vso[task.setvariable variable=appGatewayName]") $($appGW.Name.Trim())"
Write-Host "$("##vso[task.setvariable variable=appGatewayDns]") $($appGW.DnsSettings.Fqdn.Trim())"
Write-Host "$("##vso[task.setvariable variable=appGatewayRG]") $($rgName.Trim())"
Write-Host "$("##vso[task.setvariable variable=appGatewayPublicIp]") $($appGW.Id.Trim())"
