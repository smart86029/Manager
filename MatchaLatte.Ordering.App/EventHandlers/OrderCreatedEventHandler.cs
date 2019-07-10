using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Events;
using MatchaLatte.Ordering.Domain;
using MatchaLatte.Ordering.Domain.Buyers;
using MatchaLatte.Ordering.Domain.Orders;

namespace MatchaLatte.Ordering.App.EventHandlers
{
    public class OrderCreatedEventHandler : IEventHandler<OrderCreated>
    {
        private readonly IEventBus eventBus;
        private readonly IOrderingUnitOfWork unitOfWork;
        private readonly IBuyerRepository buyerRepository;
        private readonly IOrderRepository orderRepository;

        public OrderCreatedEventHandler(IEventBus eventBus, IOrderingUnitOfWork unitOfWork, IBuyerRepository buyerRepository, IOrderRepository orderRepository)
        {
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task HandleAsync(OrderCreated @event)
        {
            var buyer = await buyerRepository.GetBuyerAsync(@event.BuyerId);
            var existed = buyer != default(Buyer);

            if (!existed)
            {
                // TODO: 處理未同步
                return;
            }

            var order = await orderRepository.GetOrderAsync(@event.OrderId);
            order.SetBuyerConfirmed();

            await unitOfWork.CommitAsync();
        }
    }
}