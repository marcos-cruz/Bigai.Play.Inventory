using System.Threading.Tasks;
using Bigai.Play.Catalog.Contracts;
using Bigai.Play.Common.Repositories;
using Bigai.Play.Inventory.Service.Entities;
using MassTransit;

namespace Bigai.Play.Inventory.Service.Consumers
{
    public class CatalogItemDeletedConsumer : IConsumer<CatalogItemDeleted>
    {
        private readonly IRepository<CatalogItem> _catalogItemRepository;

        public CatalogItemDeletedConsumer(IRepository<CatalogItem> catalogItemRepository)
        {
            _catalogItemRepository = catalogItemRepository;
        }

        public async Task Consume(ConsumeContext<CatalogItemDeleted> context)
        {
            var message = context.Message;

            var item = await _catalogItemRepository.GetByIdAsync(message.ItemId);
            if (item != null)
            {
                await _catalogItemRepository.DeleteAsync(item.Id);
            }
        }
    }
}