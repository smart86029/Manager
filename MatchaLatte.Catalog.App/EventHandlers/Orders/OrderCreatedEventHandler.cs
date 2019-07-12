using System;
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
            //var group = await groupRepository.GetGroupAsync(@event.GroupId);
            //if (group == default)
            //    await RejectAsync(orderId);
            //if (@event.CreatedOn < group.StartTime || @event.CreatedOn >= group.EndTime)
            //    await RejectAsync(orderId);

            //var store = await storeRepository.GetStoreAsync(group.StoreId);
            //var products = store.ProductCategories.SelectMany(c => c.Products).ToList();
            //foreach (var orderItem in @event.OrderItems)
            //{
            //    var product = products.SingleOrDefault(p => p.Id == orderItem.ProductId);
            //    if (product == default)
            //        await RejectAsync(orderId);
            //    if (orderItem.ProductName != product.Name)
            //        await RejectAsync(orderId);

            //    var productItem = product.ProductItems.SingleOrDefault(i => i.Id == orderItem.ProductItemId);
            //    if (productItem == default)
            //        await RejectAsync(orderId);
            //    if (orderItem.ProductItemName != productItem.Name)
            //        await RejectAsync(orderId);
            //    if (orderItem.ProductItemPrice != productItem.Price)
            //        await RejectAsync(orderId);
            //}

            await ConfirmAsync(orderId);
        }

        private async Task ConfirmAsync(Guid orderId)
        {
            var @event = new OrderStockConfirmed(orderId);
            eventLogRepository.Add(new EventLog(@event));
            await unitOfWork.CommitAsync();
            await eventBus.PublishAsync(@event);
        }

        private async Task RejectAsync(Guid orderId)
        {
            var @event = new OrderStockRejected(orderId);
            eventLogRepository.Add(new EventLog(@event));
            await unitOfWork.CommitAsync();
            await eventBus.PublishAsync(@event);
        }
    }
}