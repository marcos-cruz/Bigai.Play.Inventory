using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bigai.Play.Common.Repositories;
using Bigai.Play.Inventory.Service.Clients;
using Bigai.Play.Inventory.Service.Dtos;
using Bigai.Play.Inventory.Service.Entities;
using Bigai.Play.Inventory.Service.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bigai.Play.Inventory.Service.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("items")]
    [Authorize]
    public class ItemsControllerController : ControllerBase
    {
        private readonly IRepository<InventoryItem> _inventoryItemsRepository;
        private readonly IRepository<CatalogItem> _catalogItemRepository;
        //private readonly CatalogClient _catalogClient;

        public ItemsControllerController(IRepository<InventoryItem> inventoryItemsRepository, IRepository<CatalogItem> catalogItemRepository)
        {
            _inventoryItemsRepository = inventoryItemsRepository;
            _catalogItemRepository = catalogItemRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAsync(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            //var catalogItems = await _catalogClient.GetACatalogItemsAsync();
            var inventoryItemEntities = await _inventoryItemsRepository.GetAllAsync(item => item.UserId == userId);
            var itemsIds = inventoryItemEntities.Select(item => item.CatalogItemId);
            var catalogItemsEntities = await _catalogItemRepository.GetAllAsync(item => itemsIds.Contains(item.Id));

            var inventoryItemDtos = inventoryItemEntities.Select(inventoryItem =>
            {
                var catalogItem = catalogItemsEntities.Single(catalogItem => catalogItem.Id == inventoryItem.CatalogItemId);

                return inventoryItem.AsDto(catalogItem.Name, catalogItem.Description);
            });

            return Ok(inventoryItemDtos);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(GrantItemsDto grantItemsDto)
        {
            var inventoryItem = await _inventoryItemsRepository.GetAsync(item => item.UserId == grantItemsDto.UserId &&
                                                                                 item.CatalogItemId == grantItemsDto.CatalogItemId);

            if (inventoryItem == null)
            {
                inventoryItem = new InventoryItem()
                {
                    CatalogItemId = grantItemsDto.CatalogItemId,
                    UserId = grantItemsDto.UserId,
                    Quantity = grantItemsDto.Quantity,
                    AcquiredDate = DateTimeOffset.UtcNow
                };

                await _inventoryItemsRepository.CreateAsync(inventoryItem);
            }
            else
            {
                inventoryItem.Quantity += grantItemsDto.Quantity;
                inventoryItem.AcquiredDate = DateTimeOffset.UtcNow;

                await _inventoryItemsRepository.UpdateAsync(inventoryItem);
            }

            return Ok();
        }
    }
}
