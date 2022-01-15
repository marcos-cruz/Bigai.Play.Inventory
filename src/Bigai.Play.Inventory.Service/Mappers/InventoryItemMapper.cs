using Bigai.Play.Inventory.Service.Dtos;
using Bigai.Play.Inventory.Service.Entities;

namespace Bigai.Play.Inventory.Service.Mappers
{
    public static class InventoryItemMapper
    {
        public static InventoryItemDto AsDto(this InventoryItem inventoryItem, string name, string description)
        {
            return new InventoryItemDto(inventoryItem.CatalogItemId, name, description, inventoryItem.Quantity, inventoryItem.AcquiredDate);
        }
    }
}