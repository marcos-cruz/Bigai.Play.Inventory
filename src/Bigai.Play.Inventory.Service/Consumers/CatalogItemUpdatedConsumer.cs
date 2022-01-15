using System.Threading.Tasks;
using Bigai.Play.Catalog.Contracts;
using Bigai.Play.Common.Repositories;
using Bigai.Play.Inventory.Service.Entities;
using MassTransit;

namespace Bigai.Play.Inventory.Service.Consumers
{
    public class CatalogItemUpdatedConsumer : IConsumer<CatalogItemUpdated>
    {
        private readonly IRepository<CatalogItem> _catalogItemRepository;

        public CatalogItemUpdatedConsumer(IRepository<CatalogItem> catalogItemRepository)
        {
            _catalogItemRepository = catalogItemRepository;
        }

        public async Task Consume(ConsumeContext<CatalogItemUpdated> context)
        {
            var message = context.Message;

            var item = await _catalogItemRepository.GetByIdAsync(message.ItemId);
            if (item == null)
            {
                item = new CatalogItem()
                {
                    Id = message.ItemId,
                    Name = message.Name,
                    Description = message.Description
                };

                await _catalogItemRepository.CreateAsync(item);
            }
            else
            {
                item.Name = message.Name;
                item.Description = message.Description;

                await _catalogItemRepository.UpdateAsync(item);
            }
        }
    }
}