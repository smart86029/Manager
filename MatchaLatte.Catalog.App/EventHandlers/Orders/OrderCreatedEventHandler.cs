using System;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Catalog.App.Events.Orders;
using MatchaLatte.Catalog.Domain.Groups;
using MatchaLatte.Catalog.Domain.Stores;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Catalog.App.EventHandlers.Orders
{
    public class OrderCreatedEventHandler : IEventHandler<OrderCreated>
    {
        private readonly IEventBus eventBus;
        private readonly IGroupRepository groupRepository;
        private readonly IStoreRepository storeRepository;

        public OrderCreatedEventHandler(IEventBus eventBus, IGroupRepository groupRepository, IStoreRepository storeRepository)
        {
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            this.groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            this.storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
        }

        public async Task HandleAsync(OrderCreated @event)
        {
            var group = await groupRepository.GetGroupAsync(@event.GroupId);
            if (group == default)
                Reject();
            if (@event.CreatedOn < group.StartTime || @event.CreatedOn >= group.EndTime)
                Reject();

            var store = await storeRepository.GetStoreAsync(group.StoreId);
            var products = store.ProductCategories.SelectMany(c => c.Products).ToList();
            foreach (var orderItem in @event.OrderItems)
            {
                var product = products.SingleOrDefault(p => p.Id == orderItem.ProductId);
                if (product == default)
                    Reject();
                if (orderItem.ProductName != product.Name)
                    Reject();

                var productItem = product.ProductItems.SingleOrDefault(i => i.Id == orderItem.ProductItemId);
                if (productItem == default)
                    Reject();
                if (orderItem.ProductItemName != productItem.Name)
                    Reject();
                if (orderItem.ProductItemPrice != productItem.Price)
                    Reject();
            }

            Confirm();
        }

        private void Confirm()
        {

        }

        private void Reject()
        {

        }
    }
}