using System;

namespace Bigai.Play.Inventory.Service.Dtos
{
    /// <summary>
    /// Used to grant items to a user.
    /// </summary>
    /// <param name="UserId">Id that identifies the user.</param>
    /// <param name="CatalogItemId">The catatalog item id is going to be assigned to the user.</param>
    /// <param name="Quantity">How much of the item is going to be assigned to the user.</param>
    public record GrantItemsDto(Guid UserId, Guid CatalogItemId, int Quantity);

    /// <summary>
    /// Used to return items that are assigned to a user.
    /// </summary>
    /// <param name="CatalogItemId">Catalog item id.</param>
    /// <param name="Name">Name of item in catalog of items.</param>
    /// <param name="Description">Description of item in catalog of items.</param>
    /// <param name="Quantity">Quantity.</param>
    /// <param name="AcquiredDate">Date when was put into the usrs inventory.</param>
    public record InventoryItemDto(Guid CatalogItemId, string Name, string Description, int Quantity, DateTimeOffset AcquiredDate);

    /// <summary>
    /// Used to get and merge items from catalog.
    /// </summary>
    /// <param name="Id">Id that identifies the item in the catalog of items.</param>
    /// <param name="Name">Name of item.</param>
    /// <param name="Description">Description of item.</param>
    public record CatalogItemDto(Guid Id, string Name, string Description);
}