using System;
using Bigai.Play.Common.Entities;

namespace Bigai.Play.Inventory.Service.Entities
{
    public class InventoryItem : IEntity
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        
        public Guid CatalogItemId { get; set; }
        
        public int Quantity { get; set; }
        
        public DateTimeOffset AcquiredDate { get; set; }
    }
}