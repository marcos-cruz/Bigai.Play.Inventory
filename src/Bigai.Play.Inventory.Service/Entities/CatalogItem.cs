using System;
using Bigai.Play.Common.Entities;

namespace Bigai.Play.Inventory.Service.Entities
{
    public class CatalogItem : IEntity
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}