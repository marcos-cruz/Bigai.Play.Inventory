using System.Threading.Tasks;
using Bigai.Play.Catalog.Contracts;
using Bigai.Play.Common.Repositories;
using Bigai.Play.Inventory.Service.Entities;
using MassTransit;

namespace Bigai.Play.Inventory.Service.Consumers
{
    public class CatalogItemCreatedConsumer : IConsumer<CatalogItemCreated>
    {
        private readonly IRepository<CatalogItem> _catalogItemRepository;

        public CatalogItemCreatedConsumer(IRepository<CatalogItem> catalogItemRepository)
        {
            _catalogItemRepository = catalogItemRepository;
        }

        public async Task Consume(ConsumeContext<CatalogItemCreated> context)
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
        }
    }
}