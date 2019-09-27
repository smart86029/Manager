using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Events;
using MatchaLatte.Ordering.App.Orders;
using MatchaLatte.Ordering.Domain;
using MatchaLatte.Ordering.Domain.Orders;

namespace MatchaLatte.Ordering.Events.Orders
{
    public class OrderStockConfirmedEventHandler : IEventHandler<OrderStockConfirmed>
    {
        private readonly IOrderingUnitOfWork unitOfWork;
        private readonly IOrderRepository orderRepository;

        public OrderStockConfirmedEventHandler(IOrderingUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task HandleAsync(OrderStockConfirmed @event)
        {
            var order = await orderRepository.GetOrderAsync(@event.OrderId);

            order.Confirm();
            orderRepository.Update(order);
            await unitOfWork.CommitAsync();
        }
    }
}