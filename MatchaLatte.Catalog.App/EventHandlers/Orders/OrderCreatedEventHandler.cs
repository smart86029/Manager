using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Catalog.App.Events.Orders;
using MatchaLatte.Catalog.Domain;
using MatchaLatte.Catalog.Domain.Groups;
using MatchaLatte.Catalog.Domain.Stores;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Catalog.App.EventHandlers.Orders
{
    public class OrderCreatedEventHandler : IEventHandler<OrderCreated>
    {
        private readonly IEventBus eventBus;
        private readonly ICatalogUnitOfWork unitOfWork;
        private readonly IEventLogRepository eventLogRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IStoreRepository storeRepository;

        public OrderCreatedEventHandler(IEventBus eventBus, ICatalogUnitOfWork unitOfWork,
            IEventLogRepository eventLogRepository, IGroupRepository groupRepository, IStoreRepository storeRepository)
        {
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.eventLogRepository = eventLogRepository ?? throw new ArgumentNullException(nameof(eventLogRepository));
            this.groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            this.storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
        }

        public async Task HandleAsync(OrderCreated @event)
        {
            var orderId = @event.OrderId;
            var group = await groupRepository.GetGroupAsync(@event.GroupId);
            if (group == default)
            {
                await PublishAsync(new OrderStockRejected(orderId, "團不存在"));
                return;
            }
            if (@event.CreatedOn < group.StartOn)
            {
                await PublishAsync(new OrderStockRejected(orderId, "團尚未開始"));
                return;
            }
            if (@event.CreatedOn >= group.EndOn)
            {
                await PublishAsync(new OrderStockRejected(orderId, "團已結束"));
                return;
            }

            var invalidOrderItems = new List<InvalidOrderItemDto>();
            var store = await storeRepository.GetStoreAsync(group.StoreId);
            var products = store.ProductCategories.SelectMany(c => c.Products).ToList();
            foreach (var orderItem in @event.OrderItems)
            {
                var product = products.SingleOrDefault(p => p.Id == orderItem.ProductId);
                if (product == default)
                {
                    invalidOrderItems.Add(new InvalidOrderItemDto(orderItem, "商品不存在"));
                    continue;
                }
                if (orderItem.ProductName != product.Name)
                {
                    invalidOrderItems.Add(new InvalidOrderItemDto(orderItem, "商品名稱錯誤"));
                    continue;
                }

                var productItem = product.ProductItems.SingleOrDefault(i => i.Id == orderItem.ProductItemId);
                if (productItem == default)
                {
                    invalidOrderItems.Add(new InvalidOrderItemDto(orderItem, "商品項目不存在"));
                    continue;
                }
                if (orderItem.ProductItemName != productItem.Name)
                {
                    invalidOrderItems.Add(new InvalidOrderItemDto(orderItem, "商品項目名稱錯誤"));
                    continue;
                }
                if (orderItem.ProductItemPrice != productItem.Price)
                {
                    invalidOrderItems.Add(new InvalidOrderItemDto(orderItem, "商品項目價格錯誤"));
                    continue;
                }
            }

            if (invalidOrderItems.Any())
                await PublishAsync(new OrderStockRejected(orderId, null, invalidOrderItems));
            else
                await PublishAsync(new OrderStockConfirmed(orderId));
        }

        private async Task PublishAsync(Event @event)
        {
            eventLogRepository.Add(new EventLog(@event));
            await unitOfWork.CommitAsync();
            await eventBus.PublishAsync(@event);
        }
    }
}