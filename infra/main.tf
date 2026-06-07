resource "azurerm_resource_group" "demo" {
  name     = "inventory-rg"
  location = "East US"
}

resource "azurerm_virtual_network" "vnet" {
  name                = "inventory-vnet"
  address_space       = ["10.2.0.0/16"]
  location            = azurerm_resource_group.demo.location
  resource_group_name = azurerm_resource_group.demo.name
}
